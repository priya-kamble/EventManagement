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
        //public async Task<IActionResult> Index(EventDetail eventDetail, string quantitySelected)
        public async Task<IActionResult> Index(EventDetail eventDetail)
        {
            var selectedDate = DateTime.Parse(eventDetail.DateSelected);
            var ticketCollection = await _eventService.GetTicketsPerEvent(eventDetail.Id);

            foreach(var ticketCategory in ticketCollection)
            {
                ticketCategory.AvailableTicketsQuantity = GetAvailableQuantity(ticketCategory.Quantity);
                //ticketCategory.QuantitySelected = quantitySelected;
            }

            var ticketsviewmodel = new TicketIndexViewModel
            {
                DateSelected = selectedDate,
                Tickets = ticketCollection
            };
            return View(ticketsviewmodel);
        }

        [HttpPost]
        public IActionResult GetQuantitySelected(TicketIndexViewModel ticketCollections)
        {
            
            return View(ticketCollections);
        }

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
