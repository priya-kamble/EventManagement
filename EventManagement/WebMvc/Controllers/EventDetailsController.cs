using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventDetailsController : Controller
    {
        public IActionResult Index(int id, DateTime startDate, DateTime endDate, string dateSelected)
        {

            // code to fetch Event Details from id.

            var availableDates = GetAvailableDates(startDate, endDate);

            var eventDetail = new EventDetail
            {
                Id = id,
                StartDate = startDate,
                EndDate = endDate,
                AvailableDates = availableDates,
                DateSelected = dateSelected
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
