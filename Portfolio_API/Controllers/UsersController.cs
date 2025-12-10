using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models;
using Portfolio_API.Services;

namespace Portfolio_API.Controllers
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

        [HttpGet("{userid}")]
        [EndpointSummary("Get attendance record by id")]
        public async Task<ActionResult<User>> GetAttendanceById(int userid)
        {
            var user = await this._userService.GetAttendanceById(userid);
            return Ok(user);
        }
    }
}
