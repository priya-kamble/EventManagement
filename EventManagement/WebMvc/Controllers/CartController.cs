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
                                ICartService cartService,IEventService eventService  )
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
            try
            {
                if (SelectedTicketsDetail.Tickets.Count() > 0)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var CartTicket = new CartItem();
                    
                    CartTicket.CartItemId = Guid.NewGuid().ToString();
                    CartTicket.TicketId = SelectedTicketsDetail.TicketId.ToString() ;
                    CartTicket.EventId = SelectedTicketsDetail.EventId.ToString();
                    //CartTicket.EventTitle = SelectedTicketsDetail.Event.Title;
                    CartTicket.UserSelectedDate = SelectedTicketsDetail.DateSelected;
                    CartTicket.TicketPrice = SelectedTicketsDetail.Price;
                    CartTicket.Quantity = Convert.ToInt32(SelectedTicketsDetail.QuantitySelected);
                    //CartTicket.TicketCategoryName = SelectedTicketsDetail.TicketCategory.TicketCategoryName; 
                    await _cartService.AddItemToCart(user, CartTicket);
                }
                return RedirectToAction("Index", "Ticket", new { eventId = SelectedTicketsDetail.EventId, dateselected= dateSelected });
            }
                    foreach (var t in SelectedTicketsDetail.Tickets)
                    {
                        CartTicket.CartItemId = Guid.NewGuid().ToString();
                        CartTicket.TicketId = t.TicketId.ToString();
                        CartTicket.EventId = t.EventId.ToString();
                        CartTicket.EventTitle = t.Event.Title;
                        CartTicket.UserSelectedDate = SelectedTicketsDetail.DateSelected;
                        CartTicket.TicketPrice = t.Price;
                        CartTicket.Quantity = Convert.ToInt32(t.QuantitySelected);
                        CartTicket.TicketCategoryName = t.TicketCategory.TicketCategoryName;
                        await _cartService.AddItemToCart(user, CartTicket);
                    }
                }
                return RedirectToAction("Index", "Ticket", new { id = 16, dateSelected = "02-05-2022" }); 
            }
            catch (BrokenCircuitException)
            {
                HandleBrokenCircuitException();
            }
            return RedirectToAction("Index", "Ticket", new { eventId = SelectedTicketsDetail.EventId, dateselected = dateSelected });
        }








        //[HttpPost]
        //public async Task<IActionResult> AddToCart(Ticket SelectedTicketsDetail)
        //{
        //    try
        //    {
        //        if (SelectedTicketsDetail.QuantitySelected.Count() > 0)
        //        { 
        //            var user = _identityService.Get(HttpContext.User);
        //            var CartTicket = new CartItem();

                    
        //            CartTicket.CartItemId = Guid.NewGuid().ToString();
        //            CartTicket.TicketId = SelectedTicketsDetail.TicketId.ToString() ;
        //            CartTicket.EventId = SelectedTicketsDetail.EventId.ToString();
        //            CartTicket.EventTitle = "Fly with us";
        //            CartTicket.UserSelectedDate = SelectedTicketsDetail.DateSelected;
        //            CartTicket.TicketPrice = SelectedTicketsDetail.Price;
        //            CartTicket.Quantity = Convert.ToInt32(SelectedTicketsDetail.QuantitySelected);
        //            CartTicket.TicketCategoryName = "Early Bird - Adult"; 
        //            await _cartService.AddItemToCart(user, CartTicket);

        //        }
        //        return RedirectToAction("Index", "Ticket", new { id = SelectedTicketsDetail.EventId, dateSelected = "02-05-2022" });
        //    }
        //    catch (BrokenCircuitException)
        //    {
        //        HandleBrokenCircuitException();
            
        //    }
        //    return RedirectToAction("Index", "Ticket", new { id = SelectedTicketsDetail.EventId, dateSelected = "02-05-2022" });
        //}

        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }


       
        
        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities, string action)
        {
            if (action == "[ Checkout ]")
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
