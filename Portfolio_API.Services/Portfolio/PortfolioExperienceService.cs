using System;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.Mapper;
using Portfolio_API.DataAccess.Repositories.Portfolio;

namespace Portfolio_API.Services.Portfolio;

public interface IPortfolioExperienceService : IMappedService<Experience, DTOExperience, DTOExperienceCreate>
{
    Task<List<DTOProject>> GetExperienceProjectsAsync(int experienceId);
    Task<List<DTOExperience>> GetAllWithProjectsAsync();
}
public class PortfolioExperienceService : BaseMappedPortfolioService<Experience, DTOExperience, DTOExperienceCreate>, IPortfolioExperienceService
{
  protected readonly IPortfolioExperienceRepository _expRepository;
  public PortfolioExperienceService(
    IPortfolioExperienceRepository expRepository, 
    JDBContext context, 
    IMapper<Experience, DTOExperience, DTOExperienceCreate> mapperRead)
    : base(expRepository, context, mapperRead)
  {
    _expRepository = expRepository;
  }

  public async Task<List<DTOExperience>> GetAllWithProjectsAsync()
  {
    var experiences = await _repository.GetAllAsync();
    var dtoExperiences = new List<DTOExperience>();

    foreach (var experience in experiences)
    {
        var dtoExperience = _mapper.MapToDto(experience);
        dtoExperience.Projects = await _expRepository.GetExperienceProjectsAsync(experience.ExperienceId);
        dtoExperiences.Add(dtoExperience);
    }

    return dtoExperiences;
  }
  public async Task<List<DTOProject>> GetExperienceProjectsAsync(int experienceId)
  {
    return await _expRepository.GetExperienceProjectsAsync(experienceId);
  }
}
