using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Controllers.Portfolio
{
    [ApiExplorerSettings(GroupName= "v1")] 
    [Route("api/v1/[controller]")]
    public class ProjectsController : BaseController<Project>
    {
        public ProjectsController(IService<Project> projectService) : base(projectService) { }
    }
}
