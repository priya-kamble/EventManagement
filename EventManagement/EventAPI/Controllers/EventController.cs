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

        [HttpGet("[Action]")]
        public async Task<IActionResult> Events([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 6)
        {
            var eventsCount = await _context.EventCatalog.LongCountAsync();
            
            var events = await _context.EventCatalog
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

            var eventsCount =  await query.LongCountAsync();
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

        [HttpGet("[Action]")]
        public async Task<IActionResult> EventByCategory(
                                                        [FromQuery] DateTime? ValidDate,
                                                        [FromQuery] int CategoryId,
                                                        [FromQuery] int pageIndex = 0,
                                                        [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.EventCatalog;

            query = query.Where(e => (_context.SubCategories.Any(s => s.SubCategoryId == e.SubCategoryId && s.CategoryId == CategoryId)));

            if (ValidDate.HasValue)
            {
               query = query.Where(e => e.StartDate >= ValidDate);
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
        public async Task<IActionResult> EventByFormat(
                                                        [FromQuery] DateTime? ValidDate,
                                                        [FromQuery] int FormatId,
                                                        [FromQuery] int pageIndex = 0,
                                                        [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.EventCatalog;

            query = query.Where(e => e.FormatId == FormatId);

            if (ValidDate.HasValue)
            {
                query = query.Where(e => e.StartDate >= ValidDate);
                query = query.Where(e => e.IsCancelled==false);

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

        private List<Event> ChangePictureUrl(List<Event> events)
        {
            events.ForEach(eventItem =>
                eventItem.EventImageUrl = eventItem.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogUrl"]));
            return events;
        }
    }
}