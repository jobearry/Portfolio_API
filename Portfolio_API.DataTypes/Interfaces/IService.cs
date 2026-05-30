using System;

namespace Portfolio_API.DataTypes.Interfaces;

public interface IService<TEntity>
{
  Task<int> GetCountAsync();
  Task<List<TEntity>> GetAllAsync();
  Task<TEntity> GetByIdAsync(int id);
  Task AddNewItemAsync(TEntity entity);
}
public interface IMappedService<TEntity, TDto, TDtoCreate>
  where TEntity : class
{
  Task<List<TDto>> GetAllAsync();
  Task<TDto> GetByIdAsync(int id);
  Task AddNewItemAsync(TDtoCreate entity);
}
