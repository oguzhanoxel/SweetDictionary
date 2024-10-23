using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Application.Services.Abstracts;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAsync()
	{
		var result = await _userService.GetAllAsync();
		return Ok(result);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
	{
		var result = await _userService.GetByIdAsync(id);
		if (!result.IsSuccess) BadRequest(result);
		return Ok(result);
	}
}