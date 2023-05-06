using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Services;

namespace Travel_Agency.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TravelRoutes : ControllerBase {
        private readonly ICRUDService<TravelRoutes> _travelRouteService;

        public TravelRoutes(ICRUDService<TravelRoutes> travelRouteService)
        {
            _travelRouteService = travelRouteService;
        }


    }
}
