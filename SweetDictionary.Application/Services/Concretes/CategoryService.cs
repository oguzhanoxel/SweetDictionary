using AutoMapper;
using Core.Results;
using SweetDictionary.Application.Rules;
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
	private readonly CategoryBusinessRules _businessRules;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules businessRules)
    {
        _categoryRepository = categoryRepository;
		_mapper = mapper;
		_businessRules = businessRules;
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

	public DataResult<CategoryResponseDto> Delete(Guid id)
	{
		_businessRules.CategoryShouldExistWhenRequested(id);
		Category? category = _categoryRepository.Get(x => x.Id == id);
		var deleted = _categoryRepository.Delete(category);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deleted);

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
		_businessRules.CategoryShouldExistWhenRequested(id);
		Category? category = _categoryRepository.Get(x => x.Id == id);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
		
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CategoryResponseDto> Update(Guid id, UpdateCategoryRequestDto dto)
	{
		_businessRules.CategoryShouldExistWhenRequested(id);
		Category? category = _categoryRepository.Get(x => x.Id == id);
		_mapper.Map(dto, category);
		var updated = _categoryRepository.Update(category);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(updated);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
