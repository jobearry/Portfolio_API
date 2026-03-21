using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;
using Portfolio_API.Services;

namespace Portfolio_API.Controllers.EmployeeManagement
{
    [ApiController]
    [Authorize]
    [Route("api/v2/[controller]")]
    [ApiExplorerSettings(GroupName= "v2")] 
    public class AttendanceController : BaseController<Attendance, DTOAttendance>
    {
        public AttendanceController(IBaseService<Attendance, DTOAttendance> attendanceService) : base(attendanceService) { }
    }
}
