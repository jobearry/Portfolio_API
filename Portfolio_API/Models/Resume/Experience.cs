using System;
using System.Collections.Generic;

namespace Portfolio_API.Models.Resume;

public partial class Experience
{
    public int ExperienceId { get; set; }

    public string? CompanyName { get; set; }

    public string? StartedAt { get; set; }

    public string? Description { get; set; }
}
