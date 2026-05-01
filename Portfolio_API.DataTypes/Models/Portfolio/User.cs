using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.Portfolio;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }
}
