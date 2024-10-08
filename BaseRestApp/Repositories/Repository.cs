using System.Linq.Expressions;
using BaseRestApp.Data;
using BaseRestApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BaseRestApp.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task<List<T>> GetAllAsNoTracking(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
        public async Task<T?> GetAsNoTracking(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<T>> GetAllAsTracking(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet.AsTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
            
        }
        public async Task<T?> GetAsTracking(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet.AsTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
        public async Task<bool> CreateRangeAsync(ICollection<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _db.SaveChangesAsync() > 0;
        }
        public async Task<bool> RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _db.SaveChangesAsync() > 0;
        }
}