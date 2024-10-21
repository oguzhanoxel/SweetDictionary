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

	public DataResult<CategoryResponseDto> Delete(Guid id)
	{
		Category? category = _categoryRepository.Get(x => x.Id == id);

		if (category is null) return ResultFactory.Failure<CategoryResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

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
		Category? category = _categoryRepository.Get(x => x.Id == id);

		if (category is null) return ResultFactory.Failure<CategoryResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}

	public DataResult<CategoryResponseDto> Update(Guid id, UpdateCategoryRequestDto dto)
	{
		Category? category = _categoryRepository.Get(x => x.Id == id);

		if (category is null) return ResultFactory.Failure<CategoryResponseDto>(
			null,
			message: "Not Found",
			statusCode: System.Net.HttpStatusCode.NotFound);

		_mapper.Map(dto, category);
		var updated = _categoryRepository.Update(category);
		CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(updated);

		return ResultFactory.Success(
			response,
			statusCode: System.Net.HttpStatusCode.OK);
	}
}
