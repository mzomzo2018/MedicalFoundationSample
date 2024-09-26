using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Data;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.WebAPI.Controllers
{
    /// <summary>
    /// Used to authenticate to MedicalFoundation.API
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private IConfiguration _configuration;
        /// <summary>
        /// Initializes new instance of <see cref="LoginController"/>. Primarly created by Dependency Injection process
        /// </summary>
        /// <param name="configuration">API configuration supplement. Primarly injected by Dependency Injection</param>
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Generates Json Web Token based on <see cref="AuthenticationRequest"/> object; Which used for API authorization
        /// </summary>
        /// <param name="authRequest">Required <see cref="AuthenticationRequest"/> object</param>
        /// <returns>JWT token serialized as string</returns>
        string GenerateToken(AuthenticationRequest authRequest)
        {
            // Encoding API public key into bytes
            var key = Encoding.ASCII.GetBytes(_configuration["DefaultUser:PublicKey"]);
            // Encrypting signing credentials using public key using HMAC-SHA256 algorithm
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);
            // Creating SecurityTokenDescriptor supplying:
            //  1.Token subject as ClaimsIdentity; which generated in GenerateIdentity method
            //    Token subject is necessary for transferring user claims to authorization hander; which unlocks [Authorize(Policy = "Admin")] controllers
            //  2.Audience as localhost; which equals Issuer values for testing purposes
            //    Audience should be the recipient which receives the token and analyzes it.
            //  3.Issuer as localhost provided to verify token sender
            //  4.Token expires after 15 minutes
            //  5.Signing credentials used to encrypt token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateIdentity(authRequest),
                Audience = "http://localhost:7163",
                Issuer = "http://localhost:7163",
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = credentials,
            };
            // Creating JwtSecurityTokenHandler to create SecurityToken then serialize it to string
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
        /// <summary>
        /// Validates <see cref="AuthenticationRequest"/> credentials, then generates JWT token.
        /// </summary>
        /// <param name="authRequest">Valid <see cref="AuthenticationRequest"/> credentials</param>
        /// <returns>Action result</returns>
        [HttpPost]
        public IActionResult SignIn(AuthenticationRequest authRequest)
        {
            // For testing purposes, default user credentials are stored in appsettings.json
            if (authRequest.Username == _configuration["DefaultUser:Username"] && authRequest.Password == _configuration["DefaultUser:Password"])
                return Ok("Your authorization token is: " + GenerateToken(authRequest) + ". Please authorize using Swashbuckle Swagger authorization.");
            else
                return Problem("Incorrect sign-in credentials");
        }

        private static ClaimsIdentity GenerateIdentity(AuthenticationRequest authRequest)
        {
            var identity = new ClaimsIdentity();
            // For testing purposes, all claims are applied only for default user
            var claims = new List<Claim>
            {
                new(ClaimTypes.Role, "Administrator"),
                new(ClaimTypes.Email, "admin@swift.phc"),
                new(ClaimTypes.Name, authRequest.Username)
            };
            return identity;
        }
    }
}
