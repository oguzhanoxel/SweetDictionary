using Core.Repository;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Contexts;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Persistence.Repositories.Concretes;

public class EfPostRepository : EfRepositoryBase<EfCoreDbContext, Post, Guid>, IPostRepository
{
	public EfPostRepository(EfCoreDbContext context) : base(context)
	{
	}
}
