using System;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.Mapper;

namespace Portfolio_API.Services.Portfolio;

public class BasePortfolioService<TEntity> : IService<TEntity>
  where TEntity : class
{
  private readonly IRepository<TEntity> _repository;
  private readonly JDBContext _context;
  public BasePortfolioService(IRepository<TEntity> repository, JDBContext context)
  {
    _context = context;
    _repository = repository;
  }

  public virtual async Task<List<TEntity>> GetAllAsync()
  {
    var entities = await _repository.GetAllAsync();
    if (entities is null) throw new KeyNotFoundException("Data not found");
    return entities.ToList();
  }

  public virtual async Task<TEntity> GetByIdAsync(int id)
  {
    var entity = await _repository.GetByIdAsync(id);
    if (entity is null) throw new KeyNotFoundException();
    return entity;
  }

  public virtual async Task AddNewItemAsync(TEntity entity)
  {
    await _repository.AddNewItemAsync(entity);
  }
}
