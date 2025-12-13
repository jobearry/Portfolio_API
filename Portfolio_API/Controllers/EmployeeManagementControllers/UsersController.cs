using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Services.EmployeeManagementService;

namespace Portfolio_API.Controllers.EmployeeManagementControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [EndpointSummary("Get all users")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{userid}")]
        [EndpointSummary("Get user by id")]
        public async Task<ActionResult<UserDTO>> GetUserById(int userid)
        {
            var user = await _userService.GetUserById(userid);
            return Ok(user);
        }
    }
}
