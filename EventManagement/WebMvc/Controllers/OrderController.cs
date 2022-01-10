﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly.CircuitBreaker;
using Stripe;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Services;
using Order = WebMvc.Models.OrderModels.Order;

namespace WebMvc.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartService _cartSvc;
        private readonly IEventService _eventSvc;
        private readonly IOrderService _orderSvc;
        private readonly IIdentityService<ApplicationUser> _identitySvc;
        private readonly ILogger<OrderController> _logger;
        private readonly IConfiguration _config;

        public OrderController(IConfiguration config,
            ILogger<OrderController> logger,
            IEventService eventSvc,
            IOrderService orderSvc,
            ICartService cartSvc,
            IIdentityService<ApplicationUser> identitySvc)
        {
            _identitySvc = identitySvc;
            _orderSvc = orderSvc;
            _cartSvc = cartSvc;
            _eventSvc = eventSvc;
            _logger = logger;
            _config = config;
        }

        public async Task<IActionResult> Create()
        {
            var user = _identitySvc.Get(HttpContext.User);
            var cart = await _cartSvc.GetCart(user);
            var order = _cartSvc.MapCartToOrder(cart);
            ViewBag.StripePublishableKey = _config["StripePublicKey"];
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order frmOrder)
        {
            if (ModelState.IsValid)
            {

                var user = _identitySvc.Get(HttpContext.User);

                Order order = frmOrder;

                order.UserName = user.Email;
                order.BuyerId = user.Email;
                if (!order.OrderItems.Any(O => O.TicketPrice == 0))
                {
                    var options = new RequestOptions
                    {
                        ApiKey = _config["StripePrivateKey"]
                    };
                    var chargeOptions = new ChargeCreateOptions()

                    {
                        //required
                        Amount = (int)(order.OrderTotal * 100),
                        Currency = "usd",
                        Source = order.StripeToken,
                        //optional
                        Description = string.Format("Event Finder Payment {0}", order.UserName),
                        ReceiptEmail = order.UserName,
                    };

                    var chargeService = new ChargeService();

                    Charge stripeCharge = null;
                    try
                    {
                        stripeCharge = chargeService.Create(chargeOptions, options);
                        _logger.LogDebug("Stripe charge object creation" + stripeCharge.StripeResponse.ToString());
                    }
                    catch (StripeException stripeException)
                    {
                        _logger.LogDebug("Stripe exception " + stripeException.Message);
                        ModelState.AddModelError(string.Empty, stripeException.Message);
                        return View(frmOrder);
                    }
                    try
                    {
                        if (stripeCharge.Id != null)
                        {
                            _logger.LogDebug("TransferID :" + stripeCharge.Id);
                            order.PaymentAuthCode = stripeCharge.Id;
                            _logger.LogDebug("User {userName} started order processing", user.UserName);
                            int orderId = await _orderSvc.CreateOrder(order);
                            _logger.LogDebug("User {userName} finished order processing of {orderId}.", order.UserName, order.OrderId);
                           
                            List<Ticket> tickets = new List<Ticket>();
                            foreach (var orderItem in order.OrderItems)
                            {
                                Ticket ticket = new Ticket();
                                ticket.TicketId = orderItem.TicketId;
                                ticket.Quantity = orderItem.TicketQuantity;
                                tickets.Add(ticket);
                            }
                            await _eventSvc.UpdateTicketsQuantity(tickets);
                            return RedirectToAction("Complete", new { id = orderId, userName = user.UserName });
                        }
                        else
                        {
                            ViewData["message"] = "Payment cannot be processed, try again";
                            return View(frmOrder);
                        }
                    }
                    catch (BrokenCircuitException)
                    {
                        ModelState.AddModelError("Error", "It was not possible to create a new order, please try later. (Business Msg Due to Circuit-Breaker)");
                        return View(frmOrder);
                    }
                }
                else
                {
                    _logger.LogDebug("User {userName} started order processing", user.UserName);
                    int orderId = await _orderSvc.CreateOrder(order);
                    _logger.LogDebug("User {userName} finished order processing of {orderId}.", order.UserName, order.OrderId);
                    List<Ticket> tickets = new List<Ticket>();
                    foreach (var orderItem in order.OrderItems)
                    {
                        Ticket ticket = new Ticket();
                        ticket.TicketId = orderItem.TicketId;
                        ticket.Quantity = orderItem.TicketQuantity;
                        tickets.Add(ticket);
                    }
                    await _eventSvc.UpdateTicketsQuantity(tickets);
                    return RedirectToAction("Complete", new { id = orderId, userName = user.UserName });
                }
            }
                else
                {
                    return View(frmOrder);
                }
        }

        public async Task<IActionResult> Complete(int id, string userName)
        {
            var order = await _orderSvc.GetOrder(id.ToString());
            _logger.LogInformation("User {userName} completed checkout on order {orderId}.", userName, id);
            return View(order);
        }

        public async Task<IActionResult> Detail(string orderId)
        {
            var user = _identitySvc.Get(HttpContext.User);

            var order = await _orderSvc.GetOrder(orderId);
            return View(order);
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _orderSvc.GetOrders();
            return View(vm);
        }

        private decimal GetTotal(List<Models.OrderModels.OrderItem> orderItems)
        {
            return orderItems.Select(p => p.TicketPrice * p.TicketQuantity).Sum();
        }
    }
}