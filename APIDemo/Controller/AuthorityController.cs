using APIDemo.Authority;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIDemo.Controller
{
    [ApiController]
    public class AuthorityController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public AuthorityController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpPost("auth")]
        public IActionResult Authenticate([FromBody] AppCredential credential)
        {
            var expriesAt = DateTime.UtcNow.AddMinutes(10);
            if (AppRepository.Authenticate(credential.ClientId, credential.Secret))
            {
                return Ok(new
                {
                    access_toke = CreateToken(credential.ClientId, expriesAt),
                    expries_at = expriesAt,
                });
            } else
            {
                ModelState.AddModelError("Unauthorized", "You are not authorized.");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status401Unauthorized
                };
                return new UnauthorizedObjectResult(problemDetails);
            }
        }
        private string CreateToken(string clientId, DateTime expriesAt)
        {
            var app = AppRepository.GetApplicationByClientId(clientId);
            var claims = new List<Claim>
            {
                new Claim("AppName", app?.ApplicationName??string.Empty),
                new Claim("Read", (app?.Scope??string.Empty).Contains("read")?"true":"false"),
                new Claim("Write", (app?.Scope??string.Empty).Contains("write")?"true":"false")
            };
            var secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));
            var jwt = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature),
                    claims: claims,
                    expires: expriesAt,
                    notBefore: DateTime.UtcNow
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
