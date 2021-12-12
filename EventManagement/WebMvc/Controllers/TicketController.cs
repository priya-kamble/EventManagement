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

       
        public async Task<IActionResult> Index(int id, string dateSelected)
        {
            var selectedDate = DateTime.Parse(dateSelected);
            var ticketCollection = await _eventService.GetTicketsPerEvent(id);

            foreach (var ticketCategory in ticketCollection)
            {
                ticketCategory.AvailableTicketsQuantity = GetAvailableQuantity(ticketCategory.Quantity);
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

        [HttpPost]
        public IActionResult Test(Ticket ticket)
        {
            return View();
        }
    }
}
