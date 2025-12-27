using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Models.ProjectReviewModels;
using Portfolio_API.Services.EmployeeManagementService;
using System.Text.Json;

namespace Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectReviewController : ControllerBase
    {
        [HttpPost("input")]
        [EndpointSummary("Receive input data for ProjectReview")]
        public ActionResult ParseToExcel([FromForm] ProjectInput formData)
        {
            return Ok(formData);
        }
    }
}
