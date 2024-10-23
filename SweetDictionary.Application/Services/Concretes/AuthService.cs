using AutoMapper;
using Core.Results;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Dtos.User.ResponseDtos;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Application.Services.Concretes;

public class AuthService : IAuthService
{
	private readonly UserManager<User> _userManager;
	private readonly IMapper _mapper;

	public AuthService(UserManager<User> userManager, IMapper mapper)
	{
		_userManager = userManager;
		_mapper = mapper;
	}

	public async Task<DataResult<UserResponseDto>> RegisterAsync(RegisterRequestDto dto)
	{
		User mapped = _mapper.Map<User>(dto);

		var created = await _userManager.CreateAsync(mapped, dto.Password);

		UserResponseDto response = _mapper.Map<UserResponseDto>(mapped);

		if (created.Succeeded) return ResultFactory.Success(
			response,
			statusCode:System.Net.HttpStatusCode.OK);

		return ResultFactory.Failure<UserResponseDto>(
			null,
			statusCode: System.Net.HttpStatusCode.BadRequest,
			message: string.Join(", ", created.Errors.Select(e => e.Description)));
	}
}
