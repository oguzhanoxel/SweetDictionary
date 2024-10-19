using Core.Repository;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Contexts;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Persistence.Repositories.Concretes;

public class EfCategoryRepository : EfRepositoryBase<EfCoreDbContext, Category, Guid>, ICategoryRepository
{
	public EfCategoryRepository(EfCoreDbContext context) : base(context)
	{
	}
}
