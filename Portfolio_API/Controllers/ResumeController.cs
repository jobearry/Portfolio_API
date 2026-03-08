using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models.Resume;

namespace Portfolio_API.Controllers
{
    [ApiExplorerSettings(GroupName= "v1")] 
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ResumeController : ControllerBase
    {
        [HttpGet]
        [EndpointSummary("Get all project records")]
        public async Task<ActionResult<List<Project>>> GetAllEmployees()
        {
            return Ok();
        }
    }
}