using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio;
using Portfolio_API.Services.Portfolio;

namespace Portfolio_API.Controllers.Portfolio
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName= "v1")] 
    public class Portfolio : ControllerBase
    {
        private readonly IService<Experience> _baseExpService;
        private readonly IService<TechStackDescription> _baseTechDescriptionService;
        private readonly IService<Project> _baseProjectService;
        public Portfolio(IService<Project> baseProjectService, IService<Experience> baseExpService, IService<TechStackDescription> baseTechDescriptionService)
        {
            _baseProjectService = baseProjectService;
            _baseExpService = baseExpService;
            _baseTechDescriptionService = baseTechDescriptionService;
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetPortfolioDetailsCount()
        {
            var pjCount = await _baseProjectService.GetCountAsync();
            var expCount = await _baseExpService.GetCountAsync();
            var techCount = await _baseTechDescriptionService.GetCountAsync();
            return Ok(new{pjCount, expCount, techCount});
        }
    }
}