using Portfolio_API.Contexts;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Repositories;

namespace Portfolio_API.Services.EmployeeManagementService
{
    public class AttendanceService
    {
        private readonly ICommonRepository<Attendance> _employeeRepo;
        public AttendanceService(ICommonRepository<Attendance> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<AttendanceDTO?> GetAttendanceById(int id)
        {
            var attendance = await _employeeRepo.GetByIdAsync(id);
            return new AttendanceDTO
            {
                AttendanceId = attendance!.AttendanceId,
                EmployeeId = attendance.EmployeeId,
                Date = attendance.Date,
                CheckIn = attendance.CheckIn,
                CheckOut = attendance.CheckOut,
            };
        }
        public async Task<IEnumerable<AttendanceDTO>> GetAttendance()
        {
            var attendanceRecords = await _employeeRepo.GetAllAsync();

            return attendanceRecords.Select(attendance => new AttendanceDTO
            {
                AttendanceId = attendance.AttendanceId,
                EmployeeId = attendance.EmployeeId,
                Date = attendance.Date,
                CheckIn = attendance.CheckIn,
                CheckOut = attendance.CheckOut,
            });
        }
    }
}
