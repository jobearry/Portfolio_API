using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Portfolio_API.DataTypes.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
namespace Portfolio_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly EntraOptions _entraOpts;
        private readonly JwtOptions _jwtOpts;
        public AuthController(IOptions<EntraOptions> entraOpts, IOptions<JwtOptions> jwtOpts)
        {
            _entraOpts = entraOpts.Value;
            _jwtOpts = jwtOpts.Value;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOAuth auth)
        {
            // Validate user credentials
            var providedKey = auth.Key ?? string.Empty;
            var configuredKey = _jwtOpts.Key ?? string.Empty;

            // convert to bytes (use UTF8 if storing plain text secret), then fixed-time compare
            var providedKeyBytes = Encoding.UTF8.GetBytes(providedKey);
            var configuredKeyBytes = Encoding.UTF8.GetBytes(configuredKey);

            if (!CryptographicOperations.FixedTimeEquals(providedKeyBytes, configuredKeyBytes))
                return Unauthorized();

            // validate minimum length before creating token
            if (configuredKeyBytes.Length < 32)
                return StatusCode(500, "Server configuration error: JWT key too short.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = Encoding.ASCII.GetBytes(configuredKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Name", "Jonathan Rodel"),
                    new Claim(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOpts.Expires),
                Issuer = _jwtOpts.Issuer,
                Audience = _jwtOpts.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(jwtKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        [HttpGet("me")]
        [Authorize]
        [EndpointSummary("Get current user info from token claims")]
        public ActionResult GetUser()
        {
            var allClaims = User.Claims
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.Select(c => c.Value).ToArray());

            return Ok(allClaims);
        }
    }
}