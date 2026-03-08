using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Portfolio_API.Models.DTOs;

namespace Portfolio_API.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AzureAd _opts;
        public AuthController(IOptions<AzureAd> opts)
        {
            _opts = opts.Value;
        }

        [HttpPost("me")]
        [EndpointSummary("Get user info")]
        public async Task<ActionResult> GetUser()
        {
            var oid = User.FindFirst("oid")?.Value ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var tid = User.FindFirst("tid")?.Value;
            var roles = User.Claims.Where(c => c.Type == "roles").Select(c => c.Value).ToArray();

            if (!roles.Contains("MyAppRole")) return Forbid();

            return Ok(new { oid, tid, roles });
        }
    }
}