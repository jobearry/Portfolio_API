using System;

namespace Portfolio_API.DataTypes.Models.Portfolio.DTOs;

public class DTOTechStackSpec
{
    public int SpecId { get; set; }
    public string ToolName { get; set; } = null!;
    public string? ImgSrc { get; set; }
    public int StackId { get; set; }
}
