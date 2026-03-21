using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;

public partial class DTOEmployee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string? Email { get; set; }
}
