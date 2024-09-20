using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Data;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string GenerateToken(AuthenticationRequest authRequest)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["DefaultUser:PublicKey"]);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateIdentity(authRequest),
                Audience = "http://localhost:7163",
                Issuer = "http://localhost:7163",
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = credentials,
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
        [HttpPost]
        public IActionResult SignIn(AuthenticationRequest authRequest)
        {
            if (authRequest.Username == _configuration["DefaultUser:Username"] && authRequest.Password == _configuration["DefaultUser:Password"])
                return Ok(GenerateToken(authRequest));
            else
                return Problem("Incorrect sign-in credentials");
        }

        private static ClaimsIdentity GenerateIdentity(AuthenticationRequest authRequest)
        {
            var identity = new ClaimsIdentity();
            var claims = new List<Claim>
            {
                new(ClaimTypes.Role, "Administrator"),
                new(ClaimTypes.Email, "admin@swift.phc"),
                new(ClaimTypes.Name, "The Administrator")
            };
            return identity;
        }
    }
}
