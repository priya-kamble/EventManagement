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
            [FromQuery] int? locationId,
            [FromQuery] int? formatId,
            [FromQuery] int? categoryId,
            [FromQuery] bool? ispaid,
            [FromQuery] bool? isonline,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.EventCatalog;
            query = query.Where(e => e.IsCancelled == false && e.EndDate >= DateTime.Today);

            if (startDate.HasValue)
            {
                query = query.Where(e => e.StartDate >= startDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.EndDate <= endDate);
            }

            if (locationId.HasValue)
            {
                query = query.Where(e => e.LocationId == locationId);
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

        [HttpGet("[Action]")]
     
        public async Task<IActionResult> EventDetailById(int EventId)
        {

            var EventTicketprice = _context.Tickets.Where(t => t.EventId == EventId);
            // Retrieve Minimum price
            var MinPrice = (from T in _context.Tickets where T.EventId == EventId select T.Price ).Min();

            //Retrieve Maximum price
            var MaxPrice = (from T in _context.Tickets where T.EventId == EventId select T.Price).Max();


            var EventDetailInfo = await (from E in _context.EventCatalog
                                         join C in _context.Categories
                                         on E.SubCategory.CategoryId equals C.CategoryId

                                         where (E.Id == EventId)
                                         select new EventDetails
                                         {
                                             Address = E.Address,
                                             Description = E.Description,
                                             EndDate = E.EndDate,
                                             EventImageUrl = E.EventImageUrl,
                                             EventLinkUrl = E.EventLinkUrl,
                                             Id = E.Id,
                                             IsCancelled = E.IsCancelled,
                                             IsOnlineEvent = E.IsOnlineEvent,
                                             IsPaidEvent = E.IsPaidEvent,
                                             MaxOccupancy = E.MaxOccupancy,
                                             MaxTicketsPerUser = E.MaxTicketsPerUser,
                                             StartDate = E.StartDate,
                                             SubCategoryName = E.SubCategory.SubCategoryName,
                                             Title = E.Title,
                                             State = E.Location.State,
                                             City = E.Location.City,
                                             FormatName = E.Format.FormatName,
                                             CategoryName = C.CategoryName,
                                             MinPrice= MinPrice,
                                             MaxPrice= MaxPrice
                                         }).FirstOrDefaultAsync();




            if (EventDetailInfo != null)
            {
                EventDetailInfo.EventImageUrl = EventDetailInfo.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogUrl"]);
            }

            return Ok(EventDetailInfo);

            //var EventDetail = await _context.EventCatalog.Where(e => e.Id == EventId).FirstOrDefaultAsync();
            //if (EventDetail != null)
            //{
            //    EventDetail.EventImageUrl = EventDetail.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogUrl"]);
            //}
          //  return Ok(EventDetail);
        }


    }
}


