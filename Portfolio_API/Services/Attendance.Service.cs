using Portfolio_API.Contexts;
using Portfolio_API.Models;
using Portfolio_API.Repositories;

namespace Portfolio_API.Services
{
    public class AttendanceService
    {
        private readonly IEmployeeRepository<Attendance> _employeeRepo;
        public AttendanceService(IEmployeeRepository<Attendance> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<Attendance?> GetAttendanceById(int id)
        {
            return await this._employeeRepo.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Attendance>> GetAttendance()
        {
            return await this._employeeRepo.GetAllAsync();
        }
    }
}
