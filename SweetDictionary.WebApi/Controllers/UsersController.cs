using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.User.RequestDtos;

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

	[HttpPost]
	public IActionResult Create([FromBody] CreateUserRequestDto dto)
	{
		var result = _userService.Create(dto);
		return Ok(result);
	}

	[HttpPut]
	public IActionResult Update([FromBody] UpdateUserRequestDto dto)
	{
		var result = _userService.Update(dto);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpDelete]
	public IActionResult Delete([FromBody] DeleteUserRequestDto dto)
	{
		var result = _userService.Delete(dto);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		var result = _userService.GetAll();
		return Ok(result);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetById([FromRoute] Guid id)
	{
		var result = _userService.GetById(id);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}
}
