using Core.Results;
using SweetDictionary.Domain.Dtos.Category.RequestDtos;
using SweetDictionary.Domain.Dtos.Category.ResponseDtos;

namespace SweetDictionary.Application.Services.Abstracts;

public interface ICategoryService
{
	DataResult<CategoryResponseDto> Create(CreateCategoryRequestDto dto);
	DataResult<CategoryResponseDto> Update(Guid id, UpdateCategoryRequestDto dto);
	DataResult<CategoryResponseDto> Delete(Guid id);
	DataResult<List<CategoryResponseDto>> GetAll();
	DataResult<CategoryResponseDto> GetById(Guid id);
}