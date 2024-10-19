using Core.Repository;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Contexts;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Persistence.Repositories.Concretes;

public class EfUserRepository : EfRepositoryBase<EfCoreDbContext, User, Guid>, IUserRepository
{
	public EfUserRepository(EfCoreDbContext context) : base(context)
	{
	}
}
