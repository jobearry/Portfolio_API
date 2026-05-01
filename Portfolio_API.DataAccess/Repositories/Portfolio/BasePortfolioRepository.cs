using System;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.DataAccess.Repositories.Portfolio;

public class BasePortfolioRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
  public readonly JDBContext _context;
  public readonly DbSet<TEntity> _dbSet;
  public BasePortfolioRepository(JDBContext context)
  {
    _context = context;
    _dbSet = context.Set<TEntity>();
  }

  public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
  public async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
  public async Task AddNewItemAsync(TEntity entity) {
    await _dbSet.AddAsync(entity);
    await _context.SaveChangesAsync();
  }
}