using EventAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using EventAPI.Domain;
using System.Collections.Generic;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly EventCatalogContext _context;

        public TicketController(EventCatalogContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TicketsForEvent([FromQuery] int eventId)
        {
            var returnData = await (from ticket in _context.Tickets
                    join ticketcategory in _context.TicketCategories
                    on ticket.TicketCategoryId equals ticketcategory.TicketCategoryId
                    join eventCatalog in _context.EventCatalog
                    on ticket.EventId equals eventCatalog.Id
                    where eventCatalog.Id == eventId
                    select new { Ticket = ticket, TicketCategory = ticketcategory, EventCatalog = eventCatalog }).ToListAsync();

            return this.Ok(returnData.Select(x => x.Ticket));
        }



    }
}
