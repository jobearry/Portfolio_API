using System;
using Portfolio_API.DataAccess.Data.ScaffoldExisting;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.Services.Project;

public class BaseProjectService<TEntity> : IService<TEntity> where TEntity : class
{
  private readonly IRepository<TEntity> _repository;
  private readonly JDBContext _context;
  public BaseProjectService(IRepository<TEntity> repository, JDBContext context)
  {
    _context = context;
    _repository = repository;
  }
  public virtual async Task<List<TEntity>> GetAllAsync()
  {
    var entities = await _repository.GetAllAsync();
    return entities.ToList();
  }

  public virtual async Task<TEntity> GetByIdAsync(int id)
  {
    var entity = await _repository.GetByIdAsync(id);
    if (entity == null)
    {
      throw new KeyNotFoundException();
    }
    return entity;
  }
}
