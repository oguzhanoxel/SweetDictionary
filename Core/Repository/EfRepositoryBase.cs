﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Repository;

public abstract class EfRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId>
	where TEntity : Entity<TId>, new()
	where TContext : DbContext
{
	protected readonly TContext _context;

    public EfRepositoryBase(TContext context)
    {
        _context = context;
    }

    public TEntity Create(TEntity entity)
	{
		entity.CreatedTime = DateTime.Now;
		_context.Set<TEntity>().Add(entity);
		_context.SaveChanges();
		return entity;
	}

	public TEntity Delete(TEntity entity)
	{
		_context.Set<TEntity>().Remove(entity);
		_context.SaveChanges();
		return entity;
	}

	public TEntity? Get(
		Expression<Func<TEntity, bool>> predicate,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
	{
		var query = BuildQuery(include);

		return query.SingleOrDefault(predicate);
	}

	public List<TEntity> GetAll(
		Expression<Func<TEntity, bool>>? predicate = null,
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
	{
		var query = BuildQuery(include);
		if (predicate != null) query = query.Where(predicate);

		return query.ToList();
	}

	public TEntity Update(TEntity entity)
	{
		_context.Set<TEntity>().Update(entity);
		_context.SaveChanges();
		return entity;
	}

	private IQueryable<TEntity> BuildQuery(
		Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include)
	{
		var query = _context.Set<TEntity>().AsQueryable();
		return include != null ? include(query) : query;
	}
}
