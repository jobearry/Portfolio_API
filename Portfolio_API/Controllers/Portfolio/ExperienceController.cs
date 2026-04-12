using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Controllers.EmployeeManagement;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataTypes.Models.Portfolio;

namespace Portfolio_API.Controllers.Portfolio
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : BaseController<Experience>
    {
         public ExperienceController(IService<Experience> projectService) : base(projectService) { }
    }
}
