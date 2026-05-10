using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio.DTOs;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Controllers.Portfolio
{
    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TechStackDescriptionsController: ControllerBase
    { 
        
        public TechStackDescriptionsController(IMappedService<TechStackDescription, DTOTechStackDescription, DTOTechStackDescription> stackService)
        {
            
        }
    }

    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TechStackSpecsController : ControllerBase
    { 
        public TechStackSpecsController(IMappedService<TechStackSpec, DTOTechStackSpec, DTOTechStackSpec> stackService)
        {
            
        }
    }
}
