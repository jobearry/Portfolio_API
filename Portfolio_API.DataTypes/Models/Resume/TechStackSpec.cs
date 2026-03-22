using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Resume;

public partial class TechStackSpec
{
    public int Id { get; set; }

    public string ToolName { get; set; } = null!;

    public int StackId { get; set; }

    public string? ImgSrc { get; set; }

    public DateTime? CreatedAt { get; set; }
}
