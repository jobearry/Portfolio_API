using Portfolio_API.Contexts;
using Portfolio_API.Models;
using Portfolio_API.Repositories;

namespace Portfolio_API.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository<Employee> _employeeRepo;
        public EmployeeService(IEmployeeRepository<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public async Task<IEnumerable<Employee>> ViewAllEmployees()
        {
            return await this._employeeRepo.GetAllAsync();
        }
    }
}
