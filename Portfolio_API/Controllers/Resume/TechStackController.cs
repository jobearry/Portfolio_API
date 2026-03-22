using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Models.Resume;
using Portfolio_API.Services.Resume;

namespace Portfolio_API.Controllers.Resume
{
    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TechStackDescriptionController : BaseController<TechStackDescription>
    { 
        public TechStackDescriptionController(IResumeBaseService<TechStackDescription> resumeService) : base(resumeService) { }
    }

    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TechStackSpecController : BaseController<TechStackSpec>
    { 
        public TechStackSpecController(IResumeBaseService<TechStackSpec> resumeService) : base(resumeService) { }
    }
}
