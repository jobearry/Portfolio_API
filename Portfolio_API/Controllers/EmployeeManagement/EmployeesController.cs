using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;
using Portfolio_API.Services;
using Portfolio_API.Services.Employee;
using System.Threading.Tasks;

namespace Portfolio_API.Controllers.EmployeeManagement
{
    [ApiExplorerSettings(GroupName= "v2")] 
    [Route("api/v2/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeesController : BaseController<Employee, DTOEmployee>
    {
        public EmployeesController(IEmployeeBaseService<Employee, DTOEmployee> attendanceService) : base(attendanceService) { }
    }
}
