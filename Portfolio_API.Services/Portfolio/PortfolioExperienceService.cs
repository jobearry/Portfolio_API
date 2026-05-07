using System;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.DataTypes.Models.DTOs.Portfolio;
using Portfolio_API.Mapper;
using Portfolio_API.DataAccess.Repositories.Portfolio;

namespace Portfolio_API.Services.Portfolio;

public interface IPortfolioExperienceService : IMappedService<Experience, DTOExperience>
{
    Task<IEnumerable<DTOProject>> GetProjectExperiencesAsync(int experienceId);
}
public class PortfolioExperienceService : BaseMappedPortfolioService<Experience, DTOExperience>, IPortfolioExperienceService
{
  protected readonly IPortfolioExperienceRepository _expRepository;
  public PortfolioExperienceService(IPortfolioExperienceRepository expRepository, JDBContext context, IMapper<Experience, DTOExperience> mapper)
    : base(expRepository, context, mapper)
  {
    _expRepository = expRepository;
  }

  public async Task<IEnumerable<DTOProject>> GetProjectExperiencesAsync(int experienceId)
  {
    return await _expRepository.GetProjectsPerExperienceAsync(experienceId);
  }
}
