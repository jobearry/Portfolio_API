using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;
using Portfolio_API.Services;
using Portfolio_API.Services.Employee;

namespace Portfolio_API.Controllers.EmployeeManagement
{
    [ApiController]
    [Authorize]
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName= "v2")] 
    public class AttendanceController : BaseController<Attendance, DTOAttendance>
    {
        public AttendanceController(IEmployeeBaseService<Attendance, DTOAttendance> attendanceService) : base(attendanceService) { }
    }
}
