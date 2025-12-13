using System;
using System.Collections.Generic;

namespace Portfolio_API.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? Duration { get; set; }

    public string? Description { get; set; }

    public string? CoverImg { get; set; }
}
