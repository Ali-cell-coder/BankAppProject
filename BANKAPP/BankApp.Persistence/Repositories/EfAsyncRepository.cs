using BankApp.Core.Repositories;
using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankApp.Persistence.Repositories
{
    public class EfAsyncRepository<T, TId> : IAsyncRepository<T, TId> where T : Entity<TId>
    {
        protected readonly BankAppDbContext _context;

        public EfAsyncRepository(BankAppDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var query = _context.Set<T>().AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public async Task<(List<T> Items, int TotalCount)> GetListAsync(
            Expression<Func<T, bool>>? predicate = null,
            int pageNumber = 1,
            int pageSize = 10,
            Expression<Func<T, object>>? orderBy = null,
            bool ascending = true,
            Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            if (include != null)
                query = include(query);

            var totalCount = await query.CountAsync();

            if (orderBy != null)
            {
                query = ascending
                    ? query.OrderBy(orderBy)
                    : query.OrderByDescending(orderBy);
            }

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities.ToList();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            return entities.ToList();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
} 