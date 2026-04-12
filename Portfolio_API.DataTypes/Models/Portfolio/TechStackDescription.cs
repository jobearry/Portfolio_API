using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Portfolio;

public partial class TechStackDescription
{
    public int StackId { get; set; }

    public string StackName { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<TechStackSpec> TechStackSpecs { get; set; } = new List<TechStackSpec>();
}
