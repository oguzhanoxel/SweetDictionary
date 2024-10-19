using AutoMapper;
using Core.Results;
using SweetDictionary.Application.Services.Abstracts;
using SweetDictionary.Domain.Dtos.Category.RequestDtos;
using SweetDictionary.Domain.Dtos.Category.ResponseDtos;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Application.Services.Concretes;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
		_mapper = mapper;
    }

	public DataResult<CategoryResponseDto> Create(CreateCategoryRequestDto dto)
	{
		Category created = _mapper.Map<Category>(dto);
		created.Id = Guid.NewGuid();
		var category = _categoryRepository.Create(created);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.Created);
	}

	public DataResult<CategoryResponseDto> Delete(DeleteCategoryRequestDto dto)
	{
		Category deleted = _mapper.Map<Category>(dto);
		var category = _categoryRepository.Delete(deleted);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<List<CategoryResponseDto>> GetAll()
	{
		var categories = _categoryRepository.GetAll();
		List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(categories);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CategoryResponseDto> GetById(Guid id)
	{
		var category = _categoryRepository.Get(p => p.Id == id);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CategoryResponseDto> Update(UpdateCategoryRequestDto dto)
	{
		Category updated = _mapper.Map<Category>(dto);
		var category = _categoryRepository.Update(updated);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
