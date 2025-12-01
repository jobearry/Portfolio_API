using Portfolio_API.Contexts;
using Portfolio_API.Models;

namespace Portfolio_API.Repositories
{
    public class EmployeeRepository
    {
        public EmployeeManagementDevContext empContext;
        public EmployeeRepository(EmployeeManagementDevContext context)
        {
            empContext = context;
        }

        public IEnumerable<Employee> ViewAllEmployees()
        {
            return this.empContext.Employees.ToList();
        }
    }
}
