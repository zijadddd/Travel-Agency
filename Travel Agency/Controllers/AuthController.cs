using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Models.Entities;
using Travel_Agency.Models.In;
using Travel_Agency.Models.Out;
using Travel_Agency.Services;
using Travel_Agency.Utilities;

namespace Travel_Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AuthenticationPolicy")]
    public class AuthController : ControllerBase {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("registration")]
        public async Task<ActionResult<UserOut>> Register(UserIn request) {
            if (request == null) return BadRequest("User informations for signing up does not exist in request.");
            var response = await _authService.Register(request);
            if (response.GetType() != typeof(UserOut) && response.GetType() == typeof(string)) return BadRequest(response);
            else if (response == null) return BadRequest("Something isn't good.");
            else return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserAuthInfoIn request) {
            if (request == null) return BadRequest("User authentication info does not exist in request.");
            var response = await _authService.Login(request);
            if (response.GetType() != typeof(UserAuthInfo) && response.GetType() == typeof(string)) return BadRequest(response);
            return Ok(await Helper.CreateTokenAsync(response));
        }
    }
}
