using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index(EventDetail eventDetail)
        {
            var selectedDate = DateTime.Parse(eventDetail.DateSelected);
            var ticketCollection = await _eventService.GetTicketsPerEvent(eventDetail.Id);
            var ticketsviewmodel = new TicketIndexViewModel
            {
                DateSelected = selectedDate,
                Tickets = ticketCollection
            };
            return View(ticketsviewmodel);
        }
    }
}
