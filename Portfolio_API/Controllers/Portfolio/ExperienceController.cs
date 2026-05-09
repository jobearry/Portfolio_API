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

        [HttpGet]
        public override async Task<ActionResult<List<DTOExperience>>> GetAll([FromQuery] string? include)
        {
            if (string.Equals(include, "projects", StringComparison.OrdinalIgnoreCase))
            {
                var experiencesWithProjects = await _expService.GetAllWithProjectsAsync();
                return Ok(experiencesWithProjects);
            }
            var experiences = await _expService.GetAllAsync();
            return Ok(experiences);
        }

        [HttpGet("{id}/projects")]
        public async Task<IActionResult> GetProjectsPerExperience(int id)
        {
            var projects = await _expService.GetExperienceProjectsAsync(id);
            return Ok(projects);
        }
        
    }
}
