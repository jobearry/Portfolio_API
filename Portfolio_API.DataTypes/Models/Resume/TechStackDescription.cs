using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Resume;

public partial class TechStackDescription
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? StackName { get; set; }
}
