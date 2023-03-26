using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Travel_Agency.Models.Entities;
using Travel_Agency.Models.In;
using Travel_Agency.Models.Out;
using Travel_Agency.Services;

namespace Travel_Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration) {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserOut>> Register(UserIn request) {
            if (request == null) return BadRequest("User in request does not exists.");
            if (string.IsNullOrEmpty(request.FirstName)) return BadRequest("User firstname is missing.");
            if (string.IsNullOrEmpty(request.LastName)) return BadRequest("User lastname is missing.");
            if (string.IsNullOrEmpty(request.Email)) return BadRequest("User email is missing.");
            if (string.IsNullOrEmpty(request.Address)) return BadRequest("User address is missing");
            if (string.IsNullOrEmpty(request.City)) return BadRequest("User city is missing");
            if (string.IsNullOrEmpty(request.PhoneNumber)) return BadRequest("User phone number is missing.");
            if (string.IsNullOrEmpty(request.Role)) return BadRequest("User role is missing.");
            var user = await _authService.Register(request);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserAuthInfoIn request) {
            if (request == null) return BadRequest("User authentication info does not exist in request.");
            if (string.IsNullOrEmpty(request.Username)) return BadRequest("Username is missing.");
            if (string.IsNullOrEmpty (request.Password)) return BadRequest("Password is missing.");
            var user = await _authService.Login(request);
            string token = CreateToken(user);
            return token;
        }

        private string CreateToken(UserAuthInfo request) {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, request.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
