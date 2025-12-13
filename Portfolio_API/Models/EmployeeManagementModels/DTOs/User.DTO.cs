using System;
using System.Collections.Generic;

namespace Portfolio_API.Models.EmployeeManagementModels;

public partial class UserDTO
{
    public int UserId { get; set; }

    public int? EmployeeId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Role { get; set; }

}
