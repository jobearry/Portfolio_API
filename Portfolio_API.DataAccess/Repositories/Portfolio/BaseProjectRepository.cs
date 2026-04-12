using System;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataAccess.Data.ScaffoldExisting;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.DataAccess.Repositories.Portfolio;

public class BaseProjectRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
  public readonly JDBContext _context;
  public readonly DbSet<TEntity> _dbSet;
  public BaseProjectRepository(JDBContext context)
  {
    _context = context;
    _dbSet = context.Set<TEntity>();
  }

  public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
  public async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
}