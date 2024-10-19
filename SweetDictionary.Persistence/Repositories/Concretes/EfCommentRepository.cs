using Core.Repository;
using SweetDictionary.Domain.Entities;
using SweetDictionary.Persistence.Contexts;
using SweetDictionary.Persistence.Repositories.Abstracts;

namespace SweetDictionary.Persistence.Repositories.Concretes;

public class EfCommentRepository : EfRepositoryBase<EfCoreDbContext, Comment, Guid>, ICommentRepository
{
	public EfCommentRepository(EfCoreDbContext context) : base(context)
	{
	}
}
