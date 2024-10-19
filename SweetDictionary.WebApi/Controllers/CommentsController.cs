using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Comment.RequestDtos;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
	private readonly ICommentService _commentService;

	public CommentsController(ICommentService commentService)
	{
		_commentService = commentService;
	}

	[HttpPost]
	public IActionResult Create([FromBody] CreateCommentRequestDto dto)
	{
		var result = _commentService.Create(dto);
		return Ok(result);
	}

	[HttpPut]
	public IActionResult Update([FromBody] UpdateCommentRequestDto dto)
	{
		var result = _commentService.Update(dto);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpDelete]
	public IActionResult Delete([FromBody] DeleteCommentRequestDto dto)
	{
		var result = _commentService.Delete(dto);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		var result = _commentService.GetAll();
		return Ok(result);
	}

	[HttpGet("details")]
	public IActionResult GetDetailAll()
	{
		var result = _commentService.GetDetailAll();
		return Ok(result);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetById([FromRoute] Guid id)
	{
		var result = _commentService.GetById(id);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpGet("{id:guid}/detail")]
	public IActionResult GetDetailById([FromRoute] Guid id)
	{
		var result = _commentService.GetDetailById(id);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}
}
