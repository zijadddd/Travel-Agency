using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Models.Entities;
using Travel_Agency.Services;

namespace Travel_Agency.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TravelRoutes : ControllerBase {
        private readonly ICRUDService<TravelRoute> _travelRouteService;

        public TravelRoutes(ICRUDService<TravelRoute> travelRouteService)
        {
            _travelRouteService = travelRouteService;
        }
    }
}
