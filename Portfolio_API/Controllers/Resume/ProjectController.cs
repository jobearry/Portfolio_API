using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Resume;

namespace Portfolio_API.Controllers.Resume
{
    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/[controller]")]
    public class ProjectController : BaseController<Project>
    {
        public ProjectController(IService<Project> projectService) : base(projectService) { }
    }
}
