using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrderAPI.Data;
using OrderAPI.Models;
using System.Net;
using System;
using System.Threading.Tasks;
using MassTransit;
using Common.Messaging;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersContext _ordersContext;
        private readonly IConfiguration _config;
        private readonly ILogger<OrdersController> _logger;
        private IPublishEndpoint _bus;

        public OrdersController(OrdersContext ordersContext, ILogger<OrdersController> logger, IConfiguration config,
             IPublishEndpoint bus  )
        {
            _ordersContext = ordersContext;
            _config = config;
            _logger = logger;
            _bus = bus;
        }

    [HttpGet("{id}", Name = "GetOrder")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetOrder(int id)
    {

      var item = await _ordersContext.Orders
          .Include(x => x.OrderItems)
          .SingleOrDefaultAsync(ci => ci.OrderId == id);
      if (item != null)
      {
        return Ok(item);
      }

      return NotFound();

    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetOrders()
    {
      var orders = await _ordersContext.Orders.ToListAsync();


      return Ok(orders);
    }

    [Route("new")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
      order.OrderStatus = OrderStatus.Preparing;
      order.OrderDate = DateTime.UtcNow;

      _logger.LogInformation(" Now in CreateOrder()");
      _logger.LogInformation(" Order belongs to : " + order.UserName);
      _ordersContext.Orders.Add(order);
      _ordersContext.OrderItems.AddRange(order.OrderItems);
      _logger.LogInformation(" Order added to context");
      _logger.LogInformation(" Saving Order........");

            try
            {
                await _ordersContext.SaveChangesAsync();
                _bus.Publish(new OrderCompletedEvent(order.BuyerId)).Wait();

                //6 is for ticketCategoryNumber
                int[,] ticketlist=new int[6,2] ;
                int i= 0;
                foreach ( var Item in order.OrderItems)
                {
                    ticketlist[i, 0] = Item.TicketId;
                    ticketlist[i, 1] = Item.TicketQuantity;

                }

                _bus.Publish(new OrderCompletedEvent(ticketlist)).Wait();


                return Ok(new { order.OrderId });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("An error occurred while saving Order ..." + ex.Message);
                return BadRequest();
            }
        }
    }
}