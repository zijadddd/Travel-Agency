using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Models.In;
using Travel_Agency.Models.Out;
using Travel_Agency.Services;

namespace Travel_Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<UserOut>> Register(UserRegIn request) {
            if (request == null) return BadRequest("User in request does not exists.");
            if (string.IsNullOrEmpty(request.FirstName)) return BadRequest("User firstname is missing.");
            if (string.IsNullOrEmpty(request.LastName)) return BadRequest("User lastname is missing.");
            if (string.IsNullOrEmpty(request.Email)) return BadRequest("User email is missing.");
            if (string.IsNullOrEmpty(request.Password)) return BadRequest("User password is missing.");
            if (string.IsNullOrEmpty(request.Address)) return BadRequest("User address is missing");
            if (string.IsNullOrEmpty(request.City)) return BadRequest("User city is missing");
            if (string.IsNullOrEmpty(request.PhoneNumber)) return BadRequest("User phone number is missing.");
            if (string.IsNullOrEmpty(request.Role)) return BadRequest("User role is missing.");
            var user = await _authService.Register(request);
            return Ok(user);
        }
    }
}
