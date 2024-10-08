using System.Linq.Expressions;

namespace BaseRestApp.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsNoTracking(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetAsNoTracking(Expression<Func<T, bool>>? filter = null);
    Task<List<T>> GetAllAsTracking(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetAsTracking(Expression<Func<T, bool>>? filter = null);
    Task<bool> CreateRangeAsync(ICollection<T> entities);
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> RemoveAsync(T entity);
}