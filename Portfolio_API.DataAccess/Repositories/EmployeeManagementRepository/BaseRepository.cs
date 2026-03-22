using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Models;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;

namespace Portfolio_API.DataAccess.Repositories.EmployeeManagementRepository
{
    public interface IEmployeeBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class EmployeeBaseRepository<T> : IEmployeeBaseRepository<T> where T : class
    {
        public readonly EmployeeDbContext _dbContext;
        public readonly DbSet<T> _dbSet;
        public EmployeeBaseRepository(EmployeeDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }
        
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
    }
}
