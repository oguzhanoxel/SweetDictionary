using Core.Exceptions;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Application.Rules;

public class CategoryBusinessRules
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryBusinessRules(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public void CategoryShouldExistWhenRequested(Guid id)
	{
		Category? category = _categoryRepository.Get(x => x.Id == id);
		if (category is null) throw new BusinessException("Not Found");
	}
}
