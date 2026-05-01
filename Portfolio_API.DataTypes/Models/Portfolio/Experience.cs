using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Portfolio;

public partial class Experience
{
    public int ExperienceId { get; set; }

    public string? CompanyName { get; set; }

    public DateTime? FinishedAt { get; set; }

    public string? Description { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<ExpProject> ExpProjects { get; set; } = new List<ExpProject>();
}