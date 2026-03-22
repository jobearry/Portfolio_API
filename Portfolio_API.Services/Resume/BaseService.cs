using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.Mapper;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataAccess.Repositories;
using Portfolio_API.DataAccess.Repositories.ResumeRepository;

namespace Portfolio_API.Services.Resume
{
  public interface IResumeBaseService<TEntity>
      where TEntity : class
  {
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
  }
  public class ResumeBaseService<TEntity> : IResumeBaseService<TEntity>
      where TEntity : class
  {
    private readonly IResumeBaseRepository<TEntity> _repository;
    private readonly ResumeDbContext _resumeDBContext;
    public ResumeBaseService(IResumeBaseRepository<TEntity> repository, ResumeDbContext resumeDBContext)
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
