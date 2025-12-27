using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Models.ProjectReviewModels;
using Portfolio_API.Services.EmployeeManagementService;
using Portfolio_API.Services.ProjectReviewServices;
using System.Text.Json;

namespace Portfolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectReviewController : ControllerBase
    {
        private readonly ProjectReviewInputService _pjReviewInputService;
        public ProjectReviewController(ProjectReviewInputService pjReviewInputService)
        {
            _pjReviewInputService = pjReviewInputService;
        }
        [HttpPost("input")]
        [EndpointSummary("Receive input data for ProjectReview")]
        public async Task<ActionResult> ParseToExcel([FromForm] ProjectReviewInput formData)
        {
            var result = await this._pjReviewInputService.ExportProjectInput(formData);
            var fileName = $"ProjectReviewInput_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx";
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(result.ToArray(), contentType, fileName);
        }
    }
}
