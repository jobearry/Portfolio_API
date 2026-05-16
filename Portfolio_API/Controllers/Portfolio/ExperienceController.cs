using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.Services.Portfolio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Portfolio_API.Controllers.Portfolio
{
    [Route("api/v1/portfolio/[controller]")]
    [ApiExplorerSettings(GroupName= "v1")] 
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly IPortfolioExperienceService _expService;
        public ExperiencesController(IPortfolioExperienceService expService)
        {
            _expService = expService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTOExperience>>> GetAll([FromQuery] string? include)
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
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOExperienceCreate>> GetById(int id)
        {
            try
            {
                var item = await _expService.GetByIdAsync(id);
                return Ok(item);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Data with Id {id} not found");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateExperience([FromBody] DTOExperienceCreate experience)
        {
            if (experience == null) return BadRequest("Experience data is required.");

            try
            {
                await _expService.AddNewItemAsync(experience);
                return Created(nameof(GetById), experience);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
