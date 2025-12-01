using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Services.EmployeeService _employeeService;
        public EmployeesController(Contexts.EmployeeManagementDevContext empContext)
        {
            _employeeService = new Services.EmployeeService(empContext);
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.ViewAllEmployees();
            return Ok(employees);
        }
    }
}
