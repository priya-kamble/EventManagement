using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Models.CartModels;
using WebMvc.ViewModels;

namespace WebMvc.Services
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IEventService _eventService;
        private readonly IIdentityService<ApplicationUser> _identityService;

        public CartController(IIdentityService<ApplicationUser> identityService, 
                              ICartService cartService,IEventService eventService)
        {
            _identityService = identityService;
            _cartService = cartService;
            _eventService = eventService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(TicketIndexViewModel SelectedTicketsDetail)
        {
            var dateSelected = SelectedTicketsDetail.DateSelected.ToString("MM-dd-yyyy");
            var ticketsEventId = SelectedTicketsDetail.Tickets.FirstOrDefault().EventId;
            try
            {
                string[,] value = new string[6, 2];

                if (SelectedTicketsDetail.Tickets.Count() > 0)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var CartTicket = new CartItem();

                    int I = 0;
                    foreach (var t in SelectedTicketsDetail.Tickets)
                    {
                        string a = Convert.ToString(t.TicketId);

                        value[I,0] = a ;
                        value[I, 1] = t.QuantitySelected;
                        CartTicket.CartItemId = Guid.NewGuid().ToString();
                        CartTicket.TicketId = t.TicketId.ToString();
                        CartTicket.EventId = t.EventId.ToString();
                        CartTicket.EventTitle = t.Event.Title;
                        CartTicket.UserSelectedDate = SelectedTicketsDetail.DateSelected;
                        CartTicket.TicketPrice = t.Price;
                        CartTicket.Quantity = Convert.ToInt32(t.QuantitySelected);
                        CartTicket.TicketCategoryName = t.TicketCategory.TicketCategoryName;
                        await _cartService.AddItemToCart(user, CartTicket);
                        I++;
                    }
                    var cart = new Cart();
                    cart= await _cartService.GetCart(user);
                }

                TempData.Put("QantitySelected", value);
                return RedirectToAction("Index", "Ticket", new { eventId = ticketsEventId, dateselected = dateSelected });
            }
            catch (BrokenCircuitException)
            {
                HandleBrokenCircuitException();
            }
            return RedirectToAction("Index", "Ticket", new { eventId = ticketsEventId, dateselected = dateSelected });
        }

        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }

        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities, string action)
        {
            if (action == "CHECKOUT")
            {
                return RedirectToAction("Create", "Order");
            }

            try
            {
                var user = _identityService.Get(HttpContext.User);
                var basket = await _cartService.SetQuantities(user, quantities);
                var vm = await _cartService.UpdateCart(basket);

            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit  mode               
                HandleBrokenCircuitException();
            }

            return View();
        }
    }
}
