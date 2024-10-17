using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Post.RequestDtos;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
	private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromBody]CreatePostRequestDto dto)
    {
        var result = _postService.Create(dto);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromBody]Guid id)
    {
        var result = _postService.GetById(id);
        return Ok(result);
    }
}
