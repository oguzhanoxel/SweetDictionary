using Core.Results;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.User.RequestDtos;
using SweetDictionary.Domain.Roles;

namespace SweetDictionary.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthsController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthsController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
		{
			var result = await _authService.Register(dto, UserRoles.User);
			return Ok(result);
		}
		
		[HttpPost("createadmin")]
		public async Task<IActionResult> CreateAdmin([FromBody] RegisterRequestDto dto)
		{
			var result = await _authService.Register(dto, UserRoles.Admin);
			return Ok(result);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
		{
			var result = await _authService.Login(dto);
			return Ok(result);
		}
	}
}
