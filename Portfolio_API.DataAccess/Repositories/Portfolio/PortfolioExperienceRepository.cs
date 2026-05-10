using System;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.DataAccess.Repositories.Portfolio;

public interface IPortfolioExperienceRepository : IRepository<Experience>
{
    Task<List<DTOProject>> GetExperienceProjectsAsync(int experienceId);
}
public class PortfolioExperienceRepository : BasePortfolioRepository<Experience>, IPortfolioExperienceRepository
{
  public PortfolioExperienceRepository(JDBContext context) : base(context)
  {}

  public async Task<List<DTOProject>> GetExperienceProjectsAsync(int experienceId)
  {
    var experience = await _context.Experiences.Include(e => e.ExpProjects)
                                                .ThenInclude(ep => ep.Project)
                                               .Include(e => e.ExpProjects)
                                                .ThenInclude(p => p.Techstack)
                                               .FirstOrDefaultAsync(e => e.ExperienceId == experienceId);

    if (experience is null) throw new KeyNotFoundException("Experience not found");

    return experience.ExpProjects
        .GroupBy(ep => ep.Project.ProjectId)
        .Select(g => new DTOProject
        {
            ProjectId = g.Key,
            ProjectName = g.First().Project.ProjectName,
            CoverImg = g.First().Project.CoverImg,
            Description = g.First().Project.Description,
            Contribution = g.First().Project.Contribution,
            TechStackSpecs = g.Select(ep => new DTOTechStackSpec
            {
                SpecId = ep.Techstack.SpecId,
                ToolName = ep.Techstack.ToolName,
                ImgSrc = ep.Techstack.ImgSrc,
                StackId = ep.Techstack.StackId
            }).ToList()
        }).ToList();
  }
}
