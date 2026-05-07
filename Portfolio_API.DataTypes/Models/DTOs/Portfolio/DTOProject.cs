using System;

namespace Portfolio_API.DataTypes.Models.DTOs.Portfolio;

public class DTOProject
{
  public int ProjectId { get; set; }

  public string ProjectName { get; set; } = null!;

  public string? Description { get; set; }

  public string? CoverImg { get; set; }

  public int? Duration { get; set; }

  public string? Contribution { get; set; }
  public IEnumerable<DTOTechStackSpec> TechStackSpecs { get; set; } = new List<DTOTechStackSpec>();
}
