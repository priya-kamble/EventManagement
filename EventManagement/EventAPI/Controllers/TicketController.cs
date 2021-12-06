using EventAPI.Data;
using EventAPI.Domain;
using EventAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public readonly EventCatalogContext _context;
        public readonly IConfiguration _config;
        public TicketController(EventCatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> TicketsForEvent([FromQuery] int eventId, [FromQuery] DateTime dateSelected)
        {
            var returnData = await (from ticket in _context.Tickets
                                    where ticket.EventId == eventId
                                    && ticket.SalesStartDate <= DateTime.Today.Date
                                    && ticket.SalesEndDate >= DateTime.Today.Date
                                    select new TicketDetailViewModel
                                    {
                                        Event = ticket.Event,
                                        EventId = ticket.EventId,
                                        Price = ticket.Price,
                                        Quantity = ticket.Quantity,
                                        SalesEndDate = ticket.SalesEndDate,
                                        SalesStartDate = ticket.SalesStartDate,
                                        TicketCategory = ticket.TicketCategory,
                                        TicketCategoryId = ticket.TicketCategoryId,
                                        TicketId = ticket.TicketId,
                                        SelectedEventDate = dateSelected
                                    }).ToListAsync();

            returnData.ForEach(ticket => ticket.Event.EventImageUrl = ticket.Event.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogUrl"]));

            return this.Ok(returnData);
        }



    }
}
