using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventDetailsController : Controller
    {
        private readonly IEventService _eventService;
        public EventDetailsController(IEventService eventservice)
        {
            _eventService = eventservice;
        }
        public async Task<IActionResult> Index(int id)
        {


           var EventDetail = await _eventService.GetEventDetails(id);
            // code to fetch Event Details from id.




            var availableDates = GetAvailableDates(EventDetail.StartDate, EventDetail.EndDate);

            var eventDetail = new EventDetail
            {
                Id = id,
                StartDate = EventDetail.StartDate,
                EndDate = EventDetail.EndDate,
                AvailableDates = availableDates,
                Title = EventDetail.Title,
                Description = EventDetail.Description,
                EventImageUrl = EventDetail.EventImageUrl,
                MaxOccupancy = EventDetail.MaxOccupancy,
                IsOnlineEvent = EventDetail.IsOnlineEvent,
                IsCancelled = EventDetail.IsCancelled,
                EventLinkUrl = EventDetail.EventLinkUrl,
                Address = EventDetail.Address,
                LocationId = EventDetail.LocationId,
                SubCategoryId = EventDetail.SubCategoryId,
                FormatId = EventDetail.FormatId
                // MaxTicketsPerUser
                // DateSelected = dateSelected
            };

            return View(eventDetail);

        }

        public IEnumerable<SelectListItem> GetAvailableDates(DateTime startDate, DateTime endDate)
        {
            int totalDays = (int)((endDate - startDate).TotalDays + 1);

            var dates = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text="Available Dates",
                    Selected = true
                }
            };

            for (int i = 1; i <= totalDays; i++)
            {
                dates.Add(
                    new SelectListItem
                    {
                        Value = $"{startDate.AddDays(i - 1).ToShortDateString()}",
                        Text = $"{startDate.AddDays(i - 1).ToShortDateString()}"
                    });
            }

            return dates;
        }
    }
}
