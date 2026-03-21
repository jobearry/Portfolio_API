using System;
using System.Collections.Generic;

namespace Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;

public partial class DTOAttendance
{
    public int AttendanceId { get; set; }

    public int? EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public DateTime? CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    public string? Status { get; set; }
}
