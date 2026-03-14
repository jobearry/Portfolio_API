using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Models.EmployeeManagementModels.DTOs;
using Portfolio_API.Services;
using System.Threading.Tasks;

namespace Portfolio_API.Controllers.EmployeeManagement
{
    [ApiExplorerSettings(GroupName= "v2")] 
    [Route("api/v2/[controller]")]
    [Tags("Employee Management")]
    [Authorize]
    [ApiController]
    public class EmployeesController : BaseController<Employee, DTOEmployee>
    {
        public EmployeesController(IBaseService<Employee, DTOEmployee> attendanceService) : base(attendanceService) { }
    }
}
