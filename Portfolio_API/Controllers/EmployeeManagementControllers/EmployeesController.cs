using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Contexts;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Services.EmployeeManagementService;
using System.Threading.Tasks;

namespace Portfolio_API.Controllers.EmployeeManagementControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [EndpointSummary("Get all employee records")]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAllEmployees()
        {
            var employees = await _employeeService.ViewAllEmployees();
            return Ok(employees);
        }
        [HttpGet("{employeeId}")]
        [EndpointSummary("Get employee record by id")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeService.ViewEmployeeById(employeeId);
            return Ok(employee);
        }

        [HttpPost]
        [EndpointSummary("Add a new employee record")]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(EmployeeDTO employee)
        {
            var addedEmployee = await _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetAllEmployees), new { id = addedEmployee.EmployeeId }, addedEmployee);
        }

        [HttpPut("{employeeId}")]
        [EndpointSummary("Update an existing employee record")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(int employeeId, EmployeeDTO employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployee(employeeId, employee);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

        [HttpDelete("{employeeId}")]
        [EndpointSummary("Delete an employee record")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var result = await _employeeService.DeleteEmployee(employeeId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
