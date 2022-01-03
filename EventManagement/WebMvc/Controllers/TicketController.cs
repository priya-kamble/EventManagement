using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
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

     
        [Route("[controller]/[action]/{eventId}/{dateselected}")]
        public async Task<IActionResult> Index(int eventId, string dateselected)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime selectedDate;
            if (!DateTime.TryParseExact(dateselected, "MM-dd-yyyy", enUS, DateTimeStyles.None, out selectedDate))
            {
                return View();
            }
            string[,] TicketPageParameters = new string [1, 2];
            TicketPageParameters[0, 0] = Convert.ToString(eventId) ;
            TicketPageParameters[0, 1] = Convert.ToString(selectedDate);

            TempData.Put("TicketPageParameters", TicketPageParameters);

            var ticketCollection = await _eventService.GetTicketsPerEvent(eventId);

            foreach (var ticketCategory in ticketCollection)
            {
                ticketCategory.AvailableTicketsQuantity = GetAvailableQuantity(ticketCategory.TicketId,ticketCategory.Quantity);
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

               
        public IEnumerable<SelectListItem> GetAvailableQuantity(int Ticketid, int quantity)
        {
            var qty = new List<SelectListItem>();

            for (int i = 0; i <= quantity; i++)
            {
                qty.Add(
                    new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = i.ToString(),
                        Selected = IsSelected(Ticketid, i),
                    }) ; 
            }

            return qty;
        }

        private bool IsSelected(int Ticketid, int quantity)
        {

            if (TempData.ContainsKey("QantitySelected"))
            {
                string ticketid = Convert.ToString(Ticketid);
                string Quantity = Convert.ToString(quantity);

                var myArray = TempData.Get<string[,]>("QantitySelected");

                int j = 0;
                for (j = 0; j < 6; j++)
                {
                    if (ticketid == myArray[j, 0])
                    {
                        if (Quantity == myArray[j, 1])  return true;
                    }
                }

            }
            return false;

        }






        [HttpPost]
        public IActionResult Test(Ticket ticket)
        {
            return View();
        }
    }
}
