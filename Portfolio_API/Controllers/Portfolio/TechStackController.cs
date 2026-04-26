using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.DTOs;
using Portfolio_API.DataTypes.Models.DTOs.Portfolio;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Controllers.Portfolio
{
    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/[controller]")]
    [Tags("TechStack")]
    [ApiController]
    public class TechStackDescriptionsController : BaseMappedController<TechStackDescription, DTOTechStackDescription>
    { 
        public TechStackDescriptionsController(IMappedService<TechStackDescription, DTOTechStackDescription> resumeService) : base(resumeService) { }
    }

    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/[controller]")]
    [Tags("TechStack")]
    [ApiController]
    public class TechStackSpecsController : BaseMappedController<TechStackSpec, DTOTechStackSpec>
    { 
        public TechStackSpecsController(IMappedService<TechStackSpec, DTOTechStackSpec> resumeService) : base(resumeService) { }
    }
}
