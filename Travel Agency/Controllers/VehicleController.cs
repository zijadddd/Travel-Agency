using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Models.Out;
using Travel_Agency.Services;

namespace Travel_Agency.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<VehicleOut>>> GetVehicles()
        {
            var response = await _vehicleService.Read();
            if (response.GetType() is not List<VehicleOut>) return NotFound(response);
            return Ok(response);
        }
    }
}
