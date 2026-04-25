using System;

namespace Portfolio_API.DataTypes.Interfaces;

public interface IService<TEntity>
{
  Task<List<TEntity>> GetAllAsync();
  Task<TEntity> GetByIdAsync(int id);
  Task AddNewItemAsync(TEntity entity);
}
public interface IMappedService<TEntity, TDto>
  where TEntity : class
{
  Task<List<TDto>> GetAllAsync();
  Task<TDto> GetByIdAsync(int id);
  Task AddNewItemAsync(TDto entity);
}
