using Microsoft.EntityFrameworkCore;
using Portfolio_API.Contexts;
using Portfolio_API.Models;
using Portfolio_API.Models.EmployeeManagementModels;

namespace Portfolio_API.Repositories
{
    public interface ICommonRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
    }

    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        public readonly PortfolioDbContext _dbContext;
        public readonly DbSet<T> _dbSet;
        public CommonRepository(PortfolioDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }
        
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        
        public async Task<T> AddAsync(T entity)
        {
            var entry = await _dbSet.AddAsync(entity);
            return entry.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = _dbSet.Update(entity);
            return await Task.FromResult(entry.Entity);
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            var entry = _dbSet.Remove(entity);
            return entry.Entity;
        }
    }
}
