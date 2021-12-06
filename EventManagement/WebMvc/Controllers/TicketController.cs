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
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketservice)
        {
            _ticketService = ticketservice;
        }

        [HttpPost]
        public async Task<IActionResult> Index(EventDetail eventDetail)
        {
            var selectedDate = DateTime.Parse(eventDetail.DateSelected);
            var ticketCollection = await _ticketService.GetTicketsForEventAsync(eventDetail.Id, selectedDate);
            var ticketsviewmodel = new TicketIndexViewModel
            {
                DateSelected = eventDetail.DateSelected,
                Tickets = ticketCollection
            };

            return View(ticketsviewmodel);
        }
    }
}
