using System;

namespace Portfolio_API.DataTypes.Models.Portfolio.DTOs;

public class DTOTechStackSpec
{
  public int SpecId { get; set; }
  public string ToolName { get; set; } = null!;
  public string? ImgSrc { get; set; }
  public int StackId { get; set; }
}

public class DTOTechStackDescription
{
  public int StackId { get; set; }

  public string StackName { get; set; } = null!;

  public DateTime? CreatedAt { get; set; }
}

public class DTOTechStack
{
  public int StackId { get; set; }
  public string StackName { get; set; } = null!;
  public List<DTOTechStackSpec> TechStackSpecs { get; set; } = new List<DTOTechStackSpec>();
}
