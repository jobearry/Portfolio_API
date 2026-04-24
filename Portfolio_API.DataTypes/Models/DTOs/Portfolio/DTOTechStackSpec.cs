using System;

namespace Portfolio_API.DataTypes.Models.DTOs;

public class DTOTechStackSpec
{
    public int SpecId { get; set; }

    public string ToolName { get; set; } = null!;

    public string? ImgSrc { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int StackId { get; set; }
}
