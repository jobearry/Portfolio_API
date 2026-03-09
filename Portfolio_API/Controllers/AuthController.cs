using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Portfolio_API.Models.DTOs;

namespace Portfolio_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AzureAd _opts;
        public AuthController(IOptions<AzureAd> opts)
        {
            _opts = opts.Value;
        }

        [HttpGet("whoami")]
        [Authorize]
        [EndpointSummary("Get current user info from token claims")]
        public ActionResult GetUser()
        {
            var allClaims = User.Claims
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.Select(c => c.Value).ToArray());

            var oid   = User.FindFirst("oid")?.Value
                     ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var tid   = User.FindFirst("tid")?.Value
                     ?? User.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid")?.Value;
            var name  = User.FindFirst("name")?.Value
                     ?? User.FindFirst(ClaimTypes.Name)?.Value;
            var email = User.FindFirst("preferred_username")?.Value
                     ?? User.FindFirst(ClaimTypes.Email)?.Value;
            var scopes = User.FindFirst("scp")?.Value?.Split(' ');
            var roles  = User.Claims.Where(c => c.Type == "roles"
                             || c.Type == ClaimTypes.Role)
                             .Select(c => c.Value).ToArray();

            return Ok(new { oid, tid, name, email, roles, scopes, allClaims });
        }
    }
}