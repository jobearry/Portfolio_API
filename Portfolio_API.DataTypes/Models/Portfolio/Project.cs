using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Portfolio;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public string? CoverImg { get; set; }

    public int? Duration { get; set; }

    public string? Contribution { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ExpProject> ExpProjects { get; set; } = new List<ExpProject>();
}


