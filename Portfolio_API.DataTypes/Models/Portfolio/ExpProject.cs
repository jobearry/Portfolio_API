using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Portfolio;

public partial class ExpProject
{
    public int ProjectId { get; set; }

    public int TechstackId { get; set; }

    public int ExperiencedAt { get; set; }

    public virtual Experience ExperiencedAtNavigation { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual TechStackSpec Techstack { get; set; } = null!;
}
