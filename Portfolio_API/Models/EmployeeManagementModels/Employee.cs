using System;
using System.Collections.Generic;

namespace Portfolio_API.Models.EmployeeManagementModels;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
