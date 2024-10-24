using Core.Results;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.User.RequestDtos;

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
			var result = await _authService.RegisterAsync(dto);
			if (!result.IsSuccess) BadRequest(result);
			return Ok(result);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
		{
			var result = await _authService.LoginAsync(dto);
			if (!result.IsSuccess) BadRequest(result);
			return Ok(result);
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			var result = await _authService.LogoutAsync();
			if (!result.IsSuccess) BadRequest(result);
			return Ok(result);
		}
	}
}
