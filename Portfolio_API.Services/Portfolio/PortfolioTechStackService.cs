using System;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.Mapper;
using Portfolio_API.Mapper.Portfolio;

namespace Portfolio_API.Services.Portfolio;
public interface IPortfolioTechStackService
{
  Task<List<DTOTechStack>> GetAllTechStacksAsync();
}
public class PortfolioTechStackService: IPortfolioTechStackService
{
  private readonly IRepository<TechStackDescription> _descRepository;
  private readonly IRepository<TechStackSpec> _specRepository;
  private readonly JDBContext _context;
  private readonly ITechStackMapper _mapper;

  public PortfolioTechStackService(
    IRepository<TechStackSpec> specRepository,
    IRepository<TechStackDescription> descRepository,
    JDBContext context,
    ITechStackMapper mapperRead)
  {
    _descRepository = descRepository;
    _specRepository = specRepository;
    _context = context;
    _mapper = mapperRead;
  }

  public async Task<List<DTOTechStack>> GetAllTechStacksAsync()
  {
    var descriptions = await _descRepository.GetAllAsync();
    var techStacks = new List<DTOTechStack>();

    foreach (var desc in descriptions)
    {
        var specs = await _specRepository.GetAllAsync();
        var relatedSpecs = specs.Where(s => s.StackId == desc.StackId).ToList();

        var dtoTechStack = new DTOTechStack
        {
            StackId = desc.StackId,
            StackName = desc.StackName,
            TechStackSpecs = relatedSpecs.Select(s => new DTOTechStackSpec
            {
                SpecId = s.SpecId,
                ToolName = s.ToolName,
                ImgSrc = s.ImgSrc
            }).ToList()
        };

        techStacks.Add(dtoTechStack);
    }

    return techStacks;
  }
}
