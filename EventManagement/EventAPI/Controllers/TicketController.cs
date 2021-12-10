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
        public async Task<IActionResult> TicketsForEvent([FromQuery] int eventId)
        {

            var TicketStatus = TicketsStatus(eventId);

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
                                        TicketStatus = TicketStatus,
                                    }).ToListAsync();

            returnData.ForEach(ticket => ticket.Event.EventImageUrl = ticket.Event.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogUrl"]));



            if (returnData.Count <= 0)
            {
                List<TicketDetailViewModel> NotfoundObject;

                NotfoundObject = new List<TicketDetailViewModel> { new TicketDetailViewModel { TicketId = 0, TicketStatus= TicketStatus  } };
                 return this.Ok(NotfoundObject);
            }
               return this.Ok(returnData);

    }
        
        private  string TicketsStatus( int eventId)
        {
            
            string StatusMessage=" Ticket Availablity Status";

            var returnData = _context.Tickets.Where(ticket => ticket.EventId == eventId);
            
            var NotSaleStartedTicket = returnData.Where(t => t.SalesStartDate > DateTime.Today.Date);

            var ExpiredTicket = returnData.Where(t => t.SalesEndDate < DateTime.Today.Date);


            if (returnData.Any(t => t.SalesStartDate <= DateTime.Today.Date && t.SalesEndDate >= DateTime.Today.Date))
            {
                StatusMessage = "Tickets are available";
            }
            else if (NotSaleStartedTicket.Any())
            {
                
                var MinsaleStartDate =(from c in  _context.Tickets where( c.EventId == eventId) select c.SalesStartDate ).Min();
                
                
                        StatusMessage = $"Ticket sale of  will be Started on {MinsaleStartDate.Month}/{MinsaleStartDate.Day}/{MinsaleStartDate.Year}";
            }
            else if (ExpiredTicket.Any())
            {
                var MaxsaleEndDate = (from c in _context.Tickets where (c.EventId == eventId) select c.SalesEndDate).Max();
                
                    StatusMessage = $"Ticket sale of  has been ended up on  {MaxsaleEndDate.Month}/{MaxsaleEndDate.Day}/{MaxsaleEndDate.Year}";
            }
            return (StatusMessage);
        }


    }
}
