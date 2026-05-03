using System;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Services.Portfolio;

public class PortfolioExperienceService : BasePortfolioService<Experience>
{
  public PortfolioExperienceService(IRepository<Experience> repository, JDBContext context) : base(repository, context)
  {
  }

  public override Task<List<Experience>> GetAllAsync()
  {
    var entities = _repository.GetAllAsync();
    return entities;
  }
}
