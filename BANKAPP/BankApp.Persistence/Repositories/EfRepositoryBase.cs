using BankApp.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankApp.Persistence.Repositories;

public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        if (predicate != null)
            query = query.Where(predicate);
        return await query.ToListAsync();
    }
} 