using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.DTOs.Portfolio;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.Services.Portfolio;

namespace Portfolio_API.Controllers.Portfolio
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName= "v1")] 
    [ApiController]
    public class ExperiencesController : BaseMappedController<Experience, DTOExperience>
    {
        private readonly IPortfolioExperienceService _expService;
        public ExperiencesController(IPortfolioExperienceService expService) : base(expService)
        {
            _expService = expService;
        }


        [HttpGet("{id}/projects")]
        public async Task<IActionResult> GetProjectsPerExperience(int id)
        {
            var projects = await _expService.GetProjectExperiencesAsync(id);
            return Ok(projects);
        }
    }
}
