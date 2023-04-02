using Azure.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Travel_Agency.Models.Entities;
using Travel_Agency.Models.In;
using Travel_Agency.Models.Out;
using Travel_Agency.Services;

namespace Travel_Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AuthenticationPolicy")]
    public class AuthController : ControllerBase {

        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration) {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("registration")]
        public async Task<ActionResult<UserOut>> Register(UserIn request) {
            var firstNameRegex = new Regex(@"^[a-z]*[A-Z][a-z]*$");
            var lastNameRegex = new Regex(@"^[a-z]*[A-Z][a-z]*$");
            var emailRegex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$");
            var passwordRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*]).{8,}$");
            var cityRegex = new Regex(@"^[A-Z][a-z]+(?:[ ][A-Z][a-z]+)*$");
            var homeAddressRegex = new Regex(@"^[A-Z][\p{L}\d\s.,-]*$");
            var phoneNumberRegex = new Regex(@"^(\+?\d{1,3}\s)?\(?(\d{3})\)?[-.\s]?(\d{3})[-.\s]?(\d{3,4})$");
            var roleRegex = new Regex("^[A-Z][a-z]+$");
            if (request == null) return BadRequest("User in request does not exists.");
            if (string.IsNullOrEmpty(request.FirstName)) return BadRequest("Firstname is missing.");
            if (string.IsNullOrEmpty(request.LastName)) return BadRequest("Lastname is missing.");
            if (string.IsNullOrEmpty(request.Email)) return BadRequest("Email is missing.");
            if (string.IsNullOrEmpty(request.Password)) return BadRequest("Password is missing.");
            if (string.IsNullOrEmpty(request.Address)) return BadRequest("Address is missing");
            if (string.IsNullOrEmpty(request.City)) return BadRequest("City is missing");
            if (string.IsNullOrEmpty(request.PhoneNumber)) return BadRequest("Phone number is missing.");
            if (string.IsNullOrEmpty(request.Role)) return BadRequest("Role is missing.");
            if (!firstNameRegex.IsMatch(request.FirstName)) return BadRequest("First name is not valid. Example of valid first name: John");
            if (!lastNameRegex.IsMatch(request.LastName)) return BadRequest("Last name is not valid. Example of valid last name: Smith");
            if (!emailRegex.IsMatch(request.Email)) return BadRequest("Email address is not valid. Example of valid email address: johnsmith@gmail.com");
            if (!passwordRegex.IsMatch(request.Password)) return BadRequest("Password is not valid. The password should consist of at least 8 letters, al least one capital letter, one number and one special character. Example: Abcdefg1*");
            if (!cityRegex.IsMatch(request.City)) return BadRequest("City name is not valid. Example of valid city name: New York");
            if (!homeAddressRegex.IsMatch(request.Address)) return BadRequest("Home address is not valid. Example of valid home address: Address bb");
            if (!phoneNumberRegex.IsMatch(request.PhoneNumber)) return BadRequest("Phone number is not valid. Example of valid phone numbers: +1 (123) 456-7890, 555-555-1234, +44 1234567890, 123-456-789");
            if (!request.Role.Equals("User")) return BadRequest("User role is not valid. Example of valid role: User");
            if (!roleRegex.IsMatch(request.Role)) return BadRequest("User role is not valid. Example of valid role: User");
            var user = await _authService.Register(request);
            if (user == null) return BadRequest("Something isn't good.");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserAuthInfoIn request) {
            if (request == null) return BadRequest("User authentication info does not exist in request.");
            if (string.IsNullOrEmpty(request.Username)) return BadRequest("Username is missing.");
            if (string.IsNullOrEmpty (request.Password)) return BadRequest("Password is missing.");
            var user = await _authService.Login(request);
            if (user == null) return NotFound("User is not found");
            string token = CreateToken(user);
            return token;
        }

        private string CreateToken(UserAuthInfo request) {
            List<Claim> claims = new List<Claim> {
                new Claim("username", request.Username),
                new Claim("role", request.Role.Name),
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
