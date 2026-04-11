using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.Mapper;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataAccess.Repositories;
using Portfolio_API.DataAccess.Repositories.ResumeRepository;
using Portfolio_API.DataTypes.Interfaces;

namespace Portfolio_API.Services.Resume
{
  public class ResumeBaseService<TEntity> : IService<TEntity>
      where TEntity : class
  {
    private readonly IRepository<TEntity> _repository;
    private readonly ResumeDbContext _resumeDBContext;
    public ResumeBaseService(IRepository<TEntity> repository, ResumeDbContext resumeDBContext)
    {
      _repository = repository;
      _resumeDBContext = resumeDBContext;
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
}
