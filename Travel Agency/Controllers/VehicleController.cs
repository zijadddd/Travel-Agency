using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Models.Entities;
using Travel_Agency.Services;

namespace Travel_Agency.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase {
        private readonly ICRUDService<Vehicle> _vehicleService;

        public VehicleController(ICRUDService<Vehicle> vehicleService)
        {
            _vehicleService = vehicleService;
        }
    }
}
