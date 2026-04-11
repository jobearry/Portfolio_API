using System;

namespace Portfolio_API.DataTypes.Interfaces;

  public interface IRepository<T> where T : class
  {
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
  }
