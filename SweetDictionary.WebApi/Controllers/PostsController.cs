﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostsController : ControllerBase
{
	private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

	[HttpPost]
	public IActionResult Create([FromBody] CreatePostRequestDto dto)
	{
		var result = _postService.Create(dto);
		return Ok(result);
	}

    [HttpPut("{id:guid}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] UpdatePostRequestDto dto)
    {
        var result = _postService.Update(id, dto);
        if (!result.IsSuccess) BadRequest(result);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var result = _postService.Delete(id);
        if (!result.IsSuccess) BadRequest(result);
        return Ok(result);
    }
    
	[HttpGet]
	[AllowAnonymous]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

	[HttpGet("details")]
	[AllowAnonymous]
	public IActionResult GetDetailAll()
	{
		var result = _postService.GetDetailAll();
		return Ok(result);
	}

	[HttpGet("{id:guid}")]
	[AllowAnonymous]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _postService.GetById(id);
		if (!result.IsSuccess) BadRequest(result);
		return Ok(result);
	}

	[HttpGet("{id:guid}/detail")]
	[AllowAnonymous]
	public IActionResult GetDetailById([FromRoute] Guid id)
	{
		var result = _postService.GetDetailById(id);
		if (!result.IsSuccess) BadRequest(result);
		return Ok(result);
	}
}
