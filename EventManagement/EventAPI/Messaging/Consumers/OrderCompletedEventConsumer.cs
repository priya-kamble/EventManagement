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

namespace EventAPI.Massaging.Consumers
{
    public class OrderCompletedEventConsumer : IConsumer<OrderCompletedEvent>
    {
        public readonly EventCatalogContext _context;
        public readonly IConfiguration _config;
        private readonly ILogger<OrderCompletedEventConsumer> _logger;
        public OrderCompletedEventConsumer(EventCatalogContext context, IConfiguration config , ILogger<OrderCompletedEventConsumer> logger )
        {
            _context = context;
            _config = config;
            _logger = logger;
        }


       
        public async Task Consume(ConsumeContext<OrderCompletedEvent> context)
        {
            //_logger.LogWarning("We are in consume method now...");
            //_logger.LogWarning("BuyerId:" + context.Message.BuyerId);

            //await _repository.DeleteCartAsync(context.Message.BuyerId);


            _logger.LogWarning("We are in consume method now...");
            _logger.LogWarning("Tickets:" + context.Message.Tickets);

            int[,] Ticketlist= context.Message.Tickets;
           // await TicketController.UpdateTicketsQuantity(Ticketlist);

            for (int i = 0; i == Ticketlist.Length - 1; i++)
            {
                var query = _context.Tickets.Where(t => t.TicketId == Convert.ToInt32(Ticketlist.GetValue(i, 0)));
                foreach (var item in query)
                {
                    item.Quantity = item.Quantity - Convert.ToInt32(Ticketlist.GetValue(i, 1));
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
