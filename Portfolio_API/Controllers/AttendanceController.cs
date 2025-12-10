using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models;
using Portfolio_API.Services;

namespace Portfolio_API.Controllers
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
        public async Task<ActionResult<List<Attendance>>> GetAttendance()
        {
            var attendance = await this._attendanceService.GetAttendance();
            return Ok(attendance);
        }

        [HttpGet("{attendanceId}")]
        [EndpointSummary("Get attendance record by id")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(int attendanceId)
        {
            var employeeAttendance = await this._attendanceService.GetAttendanceById(attendanceId);
            return Ok(employeeAttendance);
        }

    }
}
