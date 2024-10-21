using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Category.RequestDtos;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService _categoryService;

	public CategoriesController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	[HttpPost]
	public IActionResult Create([FromBody] CreateCategoryRequestDto dto)
	{
		var result = _categoryService.Create(dto);
		return Ok(result);
	}

	[HttpPut("{id:guid}")]
	public IActionResult Update(Guid id, [FromBody] UpdateCategoryRequestDto dto)
	{
		var result = _categoryService.Update(id, dto);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpDelete("{id:guid}")]
	public IActionResult Delete([FromRoute] Guid id)
	{
		var result = _categoryService.Delete(id);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}

	[HttpGet]
	public IActionResult GetAll()
	{
		var result = _categoryService.GetAll();
		return Ok(result);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetById([FromRoute] Guid id)
	{
		var result = _categoryService.GetById(id);
		if (!result.IsSuccess) return BadRequest(result);
		return Ok(result);
	}
}
