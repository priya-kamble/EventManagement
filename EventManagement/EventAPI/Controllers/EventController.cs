using EventAPI.Data;
using EventAPI.Domain;
using EventAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public EventController(EventCatalogContext context)
        {
            _context = context;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> Events([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 6)
        {
            var eventsCount = _context.EventCatalog.LongCountAsync();
            var events = await _context.EventCatalog
                                    .OrderBy(e => e.Id)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize)
                                    .ToListAsync();
            var model = new PaginatedEventsViewModel
            {
                Data = events,
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount.Result
            };

            return Ok(model);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> EventDates(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {

            var query = (IQueryable<Event>)_context.EventCatalog;
            if (startDate.HasValue)
            {
                query = query.Where(e => e.StartDate == startDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.EndDate == endDate);
            }

            var eventsCount = query.LongCountAsync();
            var events = await query
                                    .OrderBy(e => e.Id)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize)
                                    .ToListAsync();
            var model = new PaginatedEventsViewModel
            {
                Data = events,
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount.Result
            };

            return Ok(model);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> EventLocations(
           [FromQuery] string? city,
           [FromQuery] string? state,
           [FromQuery] int pageIndex = 0,
           [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.EventCatalog;
            if (!String.IsNullOrEmpty(city))
            {
                query = query.Where(e => e.Location.City == city);
            }

            if (!String.IsNullOrEmpty(state))
            {
                query = query.Where(e => e.Location.State == state);
            }

            var eventsCount = await query.LongCountAsync();
            var events = await query
                                    .OrderBy(e => e.Id)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize)
                                    .ToListAsync();
            var model = new PaginatedEventsViewModel
            {
                Data = events,
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount
            };

            return Ok(model);
        }
    }
}
