using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Portfolio;

public partial class TechStackSpec
{
    public int SpecId { get; set; }

    public string ToolName { get; set; } = null!;

    public string? ImgSrc { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int StackId { get; set; }

    public virtual TechStackDescription Stack { get; set; } = null!;
}
