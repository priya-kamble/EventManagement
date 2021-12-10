using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class TicketController : Controller
    {
        private readonly IEventService _eventService;
        public TicketController(IEventService eventservice)
        {
            _eventService = eventservice;
        }

        [HttpPost]
        public async Task<IActionResult> Index(EventDetail eventDetail, string quantitySelected)
        {
            var selectedDate = DateTime.Parse(eventDetail.DateSelected);
            var ticketCollection = await _eventService.GetTicketsPerEvent(eventDetail.Id);

            foreach(var ticketCategory in ticketCollection)
            {
                ticketCategory.AvailableTicketsQuantity = GetAvailableQuantity(ticketCategory.Quantity);
                ticketCategory.QuantitySelected = quantitySelected;
                ticketCategory.DateSelected = selectedDate;
            }

            var ticketsviewmodel = new TicketIndexViewModel
            {
                DateSelected = selectedDate,
                Tickets = ticketCollection
            };
            return View(ticketsviewmodel);
        }


        public IActionResult GetTicketId(int id)
        {
            return View(id);
        }

        //Adding Tickets in the cart one by one
        [HttpPost]
        public IActionResult OneTicketAtATime(Ticket ticket)
        {

            return RedirectToAction("Index", "Ticket");
            //return View(ticketsviewmodel);




            //try
            //{
            //    if (ticket.TicketId > 0)
            //    {
            //        var user = _identityService.Get(HttpContext.User);
            //        var product = new CartItem()
            //        {
            //            Id = Guid.NewGuid().ToString(),
            //            Quantity = 1,
            //            TicketCategoryName = ticket.TicketCategoryName,
            //            ------
            //        };
            //        await _cartService.AddItemToCart(user, product);
            //    }
            //    return RedirectToAction("Index", "Ticket");
            //}
            //catch (BrokenCircuitException)
            //{
            //    // Catch error when CartApi is in circuit-opened mode                 
            //    HandleBrokenCircuitException();
            //}

            //return RedirectToAction("Index", "Ticket");
        }

        //private void HandleBrokenCircuitException()
        //{
        //    TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        //}

       
        public IEnumerable<SelectListItem> GetAvailableQuantity(int quantity)
        {

            var qty = new List<SelectListItem>();
            
            for (int i = 0; i <= quantity; i++)
            {
                qty.Add(
                    new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                    }); ;
            }

            return qty;
        }
    }
}
