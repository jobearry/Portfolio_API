using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Models.EmployeeManagementModels.DTOs;
using Portfolio_API.Services;

namespace Portfolio_API.Controllers.EmployeeManagement
{
    [ApiExplorerSettings(GroupName = "v2")] 
    [Route("api/v2/[controller]")]
    [Tags("Employee Management")]
    [ApiController]
    [Authorize]
    public class UsersController : BaseController<User, DTOUser>
    {
        public UsersController(IBaseService<User, DTOUser> userService) : base(userService) { }

    }
}
