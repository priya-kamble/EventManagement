using EventAPI.Domain;
using Common.Messaging;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAPI.Data;
using Microsoft.Extensions.Configuration;
using EventAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using EventAPI.ViewModel;

namespace EventAPI.Massaging.Consumers
{
    public class OrderTicketmessageConsumer : IConsumer<OrderTicketmessage>
    {
        public readonly EventCatalogContext _Eventcontext;
        public readonly IConfiguration _config;
        private readonly ILogger<OrderTicketmessageConsumer> _logger;
        public OrderTicketmessageConsumer(EventCatalogContext Eventcontext, IConfiguration config , ILogger<OrderTicketmessageConsumer> logger )
        {
            _Eventcontext = Eventcontext;
            _config = config;
            _logger = logger;
        }



        public async Task Consume(ConsumeContext<OrderTicketmessage> context)
        {
            _logger.LogWarning("We are in consume ticket quantity method now...");
            //_logger.LogWarning("Tickets:" + context.Message.Tickets.);

            List<RegisteredTicket> Ticketlist = context.Message.RegisteredTickets;

            foreach (var Item in Ticketlist)
            {
                var query = _Eventcontext.Tickets.Where(t => t.TicketId == Item.TicketId);


                foreach (Ticket matchedTicket in query)
                { 
                    matchedTicket.Quantity -= Item.QuantitySelected;

                   // _Eventcontext.Entry(Item).State = EntityState.Modified;
                    _Eventcontext.Update(matchedTicket);
                   
                }
            }

            await _Eventcontext.SaveChangesAsync();




           
        }
    }
}
