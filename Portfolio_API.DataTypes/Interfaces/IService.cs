using System;

namespace Portfolio_API.DataTypes.Interfaces;

  public interface IService<TEntity>
      where TEntity : class
  {
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
  }
