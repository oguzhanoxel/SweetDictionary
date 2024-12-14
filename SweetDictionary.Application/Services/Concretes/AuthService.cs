using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Core.Exceptions;
using Core.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SweetDictionary.Application.Rules;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Entities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SweetDictionary.Application.Services.Concretes;

public class AuthService : IAuthService
{
	private readonly UserManager<User> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly UserBusinessRules _businessRules;
	private readonly IConfiguration _configuration;
	private readonly IMapper _mapper;

	public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper, UserBusinessRules businessRules)
	{
		_userManager = userManager;
		_roleManager = roleManager;
		_businessRules = businessRules;
		_configuration = configuration;
		_mapper = mapper;
	}

	public async Task<Result> Register(RegisterRequestDto dto, string role)
	{
		await _businessRules.UserShouldHaveValidEmailFormatWhenCreatedAsync(dto.Email);
		await _businessRules.UserShouldNOTExistWhenRequestedAsync(dto.Email);
		
		User user = _mapper.Map<User>(dto);
		user.SecurityStamp = Guid.NewGuid().ToString();

		var result = await _userManager.CreateAsync(user, dto.Password);
		if (!result.Succeeded) throw new BusinessException(result.Errors.First().Description);
		
		if (!await _roleManager.RoleExistsAsync(role)) 
			await _roleManager.CreateAsync(new IdentityRole(role));
		
		_userManager.AddToRoleAsync(user, role);
		
		return ResultFactory.Success(statusCode:HttpStatusCode.Created);
	}

	public async Task<DataResult<string>> Login(LoginRequestDto dto)
	{
		var user = await _userManager.FindByEmailAsync(dto.Email);
		if (user is null || !await _userManager.CheckPasswordAsync(user, dto.Password))
			throw new BusinessException("Email or password is incorrect");
		
		var roles = await _userManager.GetRolesAsync(user);
		var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Email, user.Email),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		};
		foreach (var role in roles)
		{
			claims.Add(new Claim(ClaimTypes.Role, role));
		}
		string token = GenerateToken(claims);
		return ResultFactory.Success(data: token, statusCode: HttpStatusCode.OK);
	}

	private string GenerateToken(List<Claim> claims)
	{
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

		var descriptor = new SecurityTokenDescriptor()
		{
			Issuer = _configuration["JWT:ValidIssuer"],
			Audience = _configuration["JWT:ValidAudience"],
			Expires = DateTime.UtcNow.AddHours(1),
			SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
			Subject = new ClaimsIdentity(claims),
		};

		var handler = new JwtSecurityTokenHandler();
		var token = handler.CreateToken(descriptor);
		return handler.WriteToken(token);
	}
}
