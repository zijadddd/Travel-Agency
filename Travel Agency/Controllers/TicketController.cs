using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Models.Entities;
using Travel_Agency.Services;

namespace Travel_Agency.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase {
        private readonly ICRUDService<Ticket> _ticketService;

        public TicketController(ICRUDService<Ticket> ticketService)
        {
            _ticketService = ticketService;
        }
    }
}
