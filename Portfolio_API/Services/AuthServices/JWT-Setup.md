# JWT Setup (simple)

This document describes a minimal, practical setup for JWT authentication in this ASP.NET Core API.

## 1 — Install package
Run from the repo root:
```bash
dotnet add Portfolio_API/Portfolio_API.csproj package Microsoft.AspNetCore.Authentication.JwtBearer
```

## 2 — Add config
Add this `Jwt` section to `appsettings.json` (use a strong secret in production):
```json
"Jwt": {
  "Key": "ReplaceWithAStrong_32+_char_secret",
  "Issuer": "PortfolioApi",
  "Audience": "PortfolioApiClients",
  "ExpiresInMinutes": 60
}

```
```csharp
//set in configuration
var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
```

## 3 — Register authentication (Program.cs)
Add these usings:
```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
```
Register JWT before `builder.Build()`:
```csharp
var jwt = builder.Configuration.GetSection("Jwt");
var key = jwt.GetValue<string>("Key");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt.GetValue<string>("Issuer"),
        ValidAudience = jwt.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
```
Enable middleware in pipeline (after `app.UseHttpsRedirection()` and before `app.MapControllers()`):
```csharp
app.UseAuthentication();
app.UseAuthorization();
```

## 4 — Issue tokens (minimal `AuthController`)
Create or update `AuthController` with a `login` endpoint that validates credentials and returns a JWT. Minimal example:
```csharp
[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IConfiguration _config;

    public AuthController(UserService userService, IConfiguration config)
    {
        _userService = userService;
        _config = config;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest req)
    {
        var user = await _userService.GetByUsernameAsync(req.Username);
        if (user == null || user.PasswordHash != req.Password) return Unauthorized();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role ?? "")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:ExpiresInMinutes"])),
            signingCredentials: creds);

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expires = token.ValidTo });
    }
}
```

## 5 — Protect endpoints
Add `[Authorize]` to controllers or actions to require a valid token:
```csharp
[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class ProtectedController : ControllerBase { ... }
```

## 6 — Test
Request token:
```bash
curl -X POST https://localhost:5001/api/v1/auth/login \
 -H "Content-Type: application/json" \
 -d '{"username":"alice","password":"secret"}'
```
Use token:
```bash
curl https://localhost:5001/api/v1/protected \
 -H "Authorization: Bearer <token>"
```

## Security notes
- Never store plain passwords — use a proper hash (BCrypt, Argon2).
- Use a long random secret (32+ chars) stored securely (environment variable or vault).
- Always use HTTPS in production.
- Consider refresh tokens and token revocation for long-lived sessions.

## Optional enhancements
- Add Swagger UI JWT support (Authorize button).
- Implement role-based authorization: `[Authorize(Roles = "Admin")]`.
- Move JWT binding into a `JwtSettings` model and `IOptions<JwtSettings>`.
