using Microsoft.EntityFrameworkCore;
using Portfolio_API.Contexts;
using Portfolio_API.Models;

namespace Portfolio_API.Repositories
{
    public interface IEmployeeRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }

    public class EmployeeRepository<T> : IEmployeeRepository<T> where T : class
    {
        public readonly PortfolioDbContext _empContext;
        public readonly DbSet<T> _dbSet;
        public EmployeeRepository(PortfolioDbContext context)
        {
            _empContext = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    }
}
