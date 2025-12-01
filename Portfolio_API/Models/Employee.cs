using System;
using System.Collections.Generic;

namespace Portfolio_API.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string? Email { get; set; }
}
