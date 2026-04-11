using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataAccess.Repositories.EmployeeManagementRepository;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.DataAccess.Repositories.ResumeRepository
{
  public class ResumeBaseRepository<T> : IRepository<T> where T : class
  {
    public readonly ResumeDbContext _dbContext;
    public readonly DbSet<T> _dbSet;

    public ResumeBaseRepository(ResumeDbContext context)
    {
      _dbContext = context;
      _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();
  }
}
