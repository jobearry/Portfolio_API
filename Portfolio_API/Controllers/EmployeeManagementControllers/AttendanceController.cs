using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Services.EmployeeManagementService;

namespace Portfolio_API.Controllers.EmployeeManagementControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;
        public AttendanceController(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        [EndpointSummary("Get all attendance record")]
        public async Task<ActionResult<List<AttendanceDTO>>> GetAttendance()
        {
            var attendance = await _attendanceService.GetAttendance();
            return Ok(attendance);
        }

        [HttpGet("{attendanceId}")]
        [EndpointSummary("Get attendance record by id")]
        public async Task<ActionResult<AttendanceDTO>> GetAttendanceById(int attendanceId)
        {
            var employeeAttendance = await _attendanceService.GetAttendanceById(attendanceId);
            return Ok(employeeAttendance);
        }

    }
}
