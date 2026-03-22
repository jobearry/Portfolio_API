using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;
using Portfolio_API.Services;
using Portfolio_API.Services.Employee;

namespace Portfolio_API.Controllers.EmployeeManagement
{
    [ApiExplorerSettings(GroupName = "v2")] 
    [Route("api/v2/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : BaseController<User, DTOUser>
    {
        public UsersController(IEmployeeBaseService<User, DTOUser> userService) : base(userService) { }

    }
}
