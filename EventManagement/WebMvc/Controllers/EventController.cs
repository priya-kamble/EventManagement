using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventservice)
        {
            _eventService = eventservice;
        }

        public async Task<IActionResult> Index(
            int? page,
            int? LocationFilterApplied,
            int? FormatFilterApplied,
            int? CategoryFilterApplied,
            string DateFilterApplied,
            string PriceFilterApplied,
            bool? OnlineFilterApplied
           )
        {
            var eventsOnPage = 10;
            DateTime? startDate = null, endDate = null;
            if (!string.IsNullOrWhiteSpace(DateFilterApplied))
            {
                DateFilterEnum selectedDateFilter = (DateFilterEnum)Enum.Parse(typeof(DateFilterEnum), DateFilterApplied);
                switch (selectedDateFilter)
                {

                    case DateFilterEnum.Today:
                        startDate = DateTime.Today;
                        endDate = DateTime.Today;
                        break;
                    case DateFilterEnum.Tomorrow:
                        startDate = DateTime.Today.AddDays(1);
                        endDate = DateTime.Today.AddDays(1);
                        break;
                    case DateFilterEnum.ThisWeek:
                        startDate = DateTime.Today;
                        endDate = DateTime.Today.AddDays(7);
                        break;
                    case DateFilterEnum.NextMonth:
                        var nextMonthDate = DateTime.Today.AddMonths(1);
                        startDate = new DateTime(nextMonthDate.Year, nextMonthDate.Month, 1);
                        endDate = new DateTime(nextMonthDate.Year, nextMonthDate.Month, DateTime.DaysInMonth(nextMonthDate.Year, nextMonthDate.Month));
                        break;
                    case DateFilterEnum.All:
                    default:
                        startDate = null;
                        endDate = null;
                        break;
                }
            }

            bool? ispaid = null;

            if (!string.IsNullOrWhiteSpace(PriceFilterApplied))
            {
                PriceFilterEnum priceFilterEnum = (PriceFilterEnum)Enum.Parse(typeof(PriceFilterEnum), PriceFilterApplied);
                switch (priceFilterEnum)
                {
                    case PriceFilterEnum.Free:
                       ispaid = false;
                        break;
                    case PriceFilterEnum.Paid:
                        ispaid = true;
                        break;
                    case PriceFilterEnum.All:
                    default:
                        ispaid = null;
                        break;
                }
            }
            //if (!(bool)OnlineFilterApplied)
            //{
            //    // clearing the client id
            //    OnlineFilterApplied = false;
            //}
            //else
            //{
            //    OnlineFilterApplied = true;
            //}

            PaginatedEvents paginatedEvents = await _eventService.GetEventsAsync(
                page ?? 0,
                eventsOnPage,
                startDate,
                endDate: endDate,
                city: null,
                state: null,
                categoryId: CategoryFilterApplied,
                FormatFilterApplied,
                LocationFilterApplied,
                OnlineFilterApplied,
                ispaid);
            var locationsData = await _eventService.GetLocationsAsync();

            var eventIndexViewModel = new EventIndexViewModel
            {
                Location = locationsData,
                Format = await _eventService.GetFormatAsync(),
                Category = await _eventService.GetCategoriesAsync(),
                Date = _eventService.GetDates(),
                Price = _eventService.GetPrice(),
                Online = OnlineFilterApplied,
                Events = paginatedEvents.Data,
                PaginationInfo = new PaginationInfo
                {
                    TotalItems = paginatedEvents.Count,
                    ItemsPerPage = paginatedEvents.PageSize,
                    ActualPage = paginatedEvents.PageIndex,
                    TotalPages = (int)Math.Ceiling((decimal)paginatedEvents.Count / eventsOnPage)
                },
                LocationFilterApplied = LocationFilterApplied,
                FormatFilterApplied = FormatFilterApplied,
                CategoryFilterApplied = CategoryFilterApplied,
                DateFilterApplied = DateFilterApplied,
                PriceFilterApplied = PriceFilterApplied,
                OnlineFilterApplied = false,
            };

            return View(eventIndexViewModel);
        }
    }
}
