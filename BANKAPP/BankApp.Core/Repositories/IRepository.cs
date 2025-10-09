using System.Linq.Expressions;

namespace BankApp.Core.Repositories;

public interface IRepository<T> where T : class
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null);
} 