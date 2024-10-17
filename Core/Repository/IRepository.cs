using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Repository;

public interface IRepository<TEntity, TId>
	where TEntity : Entity<TId>, new()
{
	TEntity Create(TEntity entity);
	TEntity Update(TEntity entity);
	TEntity Delete(TEntity entity);
	TEntity? Get(
		Expression<Func<TEntity, bool>> predicate,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
	List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
}
