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

		[HttpPost]
		public async Task<IActionResult> Register(RegisterRequestDto dto)
		{
			var result = await _authService.RegisterAsync(dto);
			if (!result.IsSuccess) BadRequest(result);
			return Ok(result);
		}
	}
}
