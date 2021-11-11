using EventAPI.Data;
using EventAPI.Domain;
using EventAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public readonly EventCatalogContext _context;
        public readonly IConfiguration _config;
        public EventController(EventCatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //API to retrieve Past Events

        [HttpGet("[Action]")]
        public async Task<IActionResult> PastEvents(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.EventCatalog;
            query = query.Where(e => e.EndDate < DateTime.Today);

            return await GetEvents(pageIndex, pageSize, query);

        }

        //API to retrieve Cancelled Events

        [HttpGet("[Action]")]
        public async Task<IActionResult> CancelledEvents(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.EventCatalog;
            query = query.Where(e => e.IsCancelled == true);

            return await GetEvents(pageIndex, pageSize, query);

        }

        //API to retrieve Active Events

        [HttpGet("[Action]")]
        public async Task<IActionResult> Events(
            [FromQuery] DateTime? startDate, 
            [FromQuery] DateTime? endDate,
            [FromQuery] string city,
            [FromQuery] string state,
            [FromQuery] int? formatId,
            [FromQuery] int? categoryId,
            [FromQuery] bool? ispaid, 
            [FromQuery] bool? isonline,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.EventCatalog;
            query = query.Where(e => e.IsCancelled == false && e.StartDate >= DateTime.Today);

            if (startDate.HasValue)
            {
                query = query.Where(e => e.StartDate >= startDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.EndDate <= endDate);
            }

            if (!String.IsNullOrEmpty(city))
            {
                query = query.Where(e => e.Location.City == city);
            }

            if (!String.IsNullOrEmpty(state))
            {
                query = query.Where(e => e.Location.State == state);
            }

            if (formatId.HasValue)
            {
                query = query.Where(e => e.FormatId == formatId);
            }

            if (categoryId.HasValue)
            {
                query = query.Where(e => (_context.SubCategories.Any(s => s.SubCategoryId == e.SubCategoryId && s.CategoryId == categoryId)));
            }

            if (ispaid.HasValue)
            {
                query = query.Where(e => e.IsPaidEvent == ispaid);
            }

            if (isonline.HasValue)
            {
                query = query.Where(e => e.IsOnlineEvent == isonline);
            }

            return await GetEvents(pageIndex, pageSize, query);

        }

        private async Task<IActionResult> GetEvents(int pageIndex, int pageSize, IQueryable<Event> query)
        {
            var eventsCount = await query.LongCountAsync();
            var events = await query
                                    .OrderBy(e => e.Id)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize)
                                    .ToListAsync();
            events = ChangePictureUrl(events);
            var model = new PaginatedEventsViewModel
            {
                Data = events,
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount
            };
            return Ok(model);
        }

        private List<Event> ChangePictureUrl(List<Event> events)
        {
            events.ForEach(eventItem =>
                eventItem.EventImageUrl = eventItem.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogUrl"]));
            return events;
        }
    }
}


