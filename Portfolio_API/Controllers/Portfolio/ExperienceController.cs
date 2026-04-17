using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Controllers.Portfolio
{
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName= "v1")] 
    [ApiController]
    public class ExperienceController : BaseController<Experience>
    {
         public ExperienceController(IService<Experience> expService) : base(expService) { }
    }
}
