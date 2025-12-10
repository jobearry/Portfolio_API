using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Contexts;
using Portfolio_API.Models;
using Portfolio_API.Services;
using System.Threading.Tasks;

namespace Portfolio_API.Controllers
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
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var employees = await this._employeeService.ViewAllEmployees();
            return Ok(employees);
        }
    }
}
