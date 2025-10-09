using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankApp.Core.Repositories;

namespace BankApp.Core.Repositories
{
    public interface IAsyncRepository<T, TId> where T : Entity<TId>
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
        Task<(List<T> Items, int TotalCount)> GetListAsync(
            Expression<Func<T, bool>>? predicate = null,
            int pageNumber = 1,
            int pageSize = 10,
            Expression<Func<T, object>>? orderBy = null,
            bool ascending = true,
            Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<List<T>> UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
} 