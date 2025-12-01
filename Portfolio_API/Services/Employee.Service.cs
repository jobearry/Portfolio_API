using Portfolio_API.Contexts;

namespace Portfolio_API.Services
{
    public class EmployeeService
    {
        private readonly Repositories.EmployeeRepository _employeeRepo;
        public EmployeeService(EmployeeManagementDevContext empContext)
        {
            _employeeRepo = new Repositories.EmployeeRepository(empContext);
        }
        public IEnumerable<Models.Employee> ViewAllEmployees()
        {
            return this._employeeRepo.ViewAllEmployees();
        }
    }
}
