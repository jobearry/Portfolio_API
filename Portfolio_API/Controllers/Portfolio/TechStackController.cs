using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.Services.Portfolio;
using Microsoft.AspNetCore.Authorization;

namespace Portfolio_API.Controllers.Portfolio
{
    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/portfolio/techstack")]
    [Tags("TechStack")]
    [ApiController]
    public class TechStackController: ControllerBase
    { 
        private readonly IPortfolioTechStackService _stackService;
        private readonly IMappedService<TechStackDescription, DTOTechStackDescription, DTOTechStackDescription> _mappedDescService;
        private readonly IMappedService<TechStackSpec, DTOTechStackSpec, DTOTechStackSpec> _mappedSpecService;
        public TechStackController(
            IPortfolioTechStackService stackService, 
            IMappedService<TechStackDescription, DTOTechStackDescription, DTOTechStackDescription> mappedDescService, 
            IMappedService<TechStackSpec, DTOTechStackSpec, DTOTechStackSpec> mappedSpecService)
        {
            _stackService = stackService;
            _mappedDescService = mappedDescService;
            _mappedSpecService = mappedSpecService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DTOTechStack>>> GetAllTechStacks()
        {
            var techStacks = await _stackService.GetAllTechStacksAsync();
            return Ok(techStacks);
        }

        [HttpGet("descriptions")]
        public async Task<ActionResult<List<DTOTechStackDescription>>> GetAllDescriptions()
        {
            var descriptions = await _mappedDescService.GetAllAsync();
            return Ok(descriptions);
        }
        [HttpGet("specs")]
        public async Task<ActionResult<List<DTOTechStackSpec>>> GetAllSpecifications()
        {
            var specifications = await _mappedSpecService.GetAllAsync();
            return Ok(specifications);
        }

        [HttpPost("descriptions")]
        [Authorize]
        public async Task<ActionResult<DTOTechStackDescription>> CreateTechStackDescription(DTOTechStackDescription dtoDesc)
        {
            if(dtoDesc is null) return BadRequest("Tech stack description data is required.");
            try
            {
                await _mappedDescService.AddNewItemAsync(dtoDesc);
                return Ok(dtoDesc);
            }
            catch
            {
                return BadRequest("Error occurred while creating tech stack description.");
            }
        }

        [HttpPost("specs")]
        [Authorize]
        public async Task<ActionResult<DTOTechStackSpec>> CreateTechStackSpecification(DTOTechStackSpec dtoSpec)
        {
            if(dtoSpec is null) return BadRequest("Tech stack specification data is required.");
            try
            {
                await _mappedSpecService.AddNewItemAsync(dtoSpec);
                return Ok(dtoSpec);
            }
            catch
            {
                return BadRequest("Error occurred while creating tech stack specification.");
            }
        }
    }
}
