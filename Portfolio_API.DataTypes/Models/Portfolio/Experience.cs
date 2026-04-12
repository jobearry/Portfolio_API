using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Portfolio;

public partial class Experience
{
    public int ExperienceId { get; set; }

    public string? CompanyName { get; set; }

    public DateTime? StartedAt { get; set; }

    public string? Description { get; set; }

    public string Role { get; set; } = null!;
}