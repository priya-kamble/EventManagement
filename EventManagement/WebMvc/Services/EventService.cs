using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;
        public EventService(IConfiguration config, IHttpClient client)
        {
            
            _baseUrl = $"{config["CatalogUrl"]}/api/";
            _client = client;
        }
        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categoryUri = ApiPaths.Event.GetAllCategory(_baseUrl);

            var dataString = await _client.GetStringAsync(categoryUri);

            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text="All",
                    Selected = true
                }
            };

            var categories = JArray.Parse(dataString);
            foreach (var category in categories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("categoryId"),
                        Text = category.Value<string>("categoryName")
                    });
            }
            return items;
        }

        public IEnumerable<SelectListItem> GetDates()
        {
            var dates = new List<SelectListItem>();

            dates.Add(new SelectListItem()
            {
                Value = DateFilterEnum.All.ToString(),
                Text = "All",
                Selected= true

            });
            dates.Add(new SelectListItem()
            {
                Value = DateFilterEnum.Today.ToString(),
                Text = "Today"
            });

            dates.Add(new SelectListItem()
            {
                Value = DateFilterEnum.Tomorrow.ToString(),
                Text = "Tomorrow"
            });

            dates.Add(new SelectListItem()
            {
                Value = DateFilterEnum.ThisWeek.ToString(),
                Text = "This Week"
            });

            dates.Add(new SelectListItem()
            {
                Value = DateFilterEnum.NextMonth.ToString(),
                Text = "Next Month"
            });
            return dates;
        }

        public async Task<PaginatedEvents> GetEventsAsync(
            int page,
            int size,
            DateTime? startDate,
            DateTime? endDate,
            int? categoryId,
            int? formatId,
            int? locationId,
            bool? isOnline,
            bool? isPaid)
        {
            var eventsUri = ApiPaths.Event.GetAllEvent(_baseUrl, page, size, startDate, endDate, locationId, formatId, categoryId, isPaid, isOnline);
            var dataString = await _client.GetStringAsync(eventsUri);
            return JsonConvert.DeserializeObject<PaginatedEvents>(dataString);
        }

        
         public async Task<EventDe> GetEventDetails(int eventId)
        {

            var eventsUri = ApiPaths.Event.GetEventByID(_baseUrl, eventId);
            var dataString = await _client.GetStringAsync(eventsUri);
            return JsonConvert.DeserializeObject<EventDetails>(dataString); 
         
        }
        public async Task<IEnumerable<SelectListItem>> GetFormatAsync()
        {
            var formatUri = ApiPaths.Event.GetAllFormat(_baseUrl);
            var dataString = await _client.GetStringAsync(formatUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text="All",
                    Selected = true
                }
            };
            var formats = JArray.Parse(dataString);
            foreach (var format in formats)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = format.Value<string>("formatId"),
                        Text = format.Value<string>("formatName")
                    });
            }
            return items;
        }
        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {
            var locationUri = ApiPaths.Event.GetAllLocation(_baseUrl);
            var dataString = await _client.GetStringAsync(locationUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text="All",
                    Selected = true
                }
            };
            var locations = JArray.Parse(dataString);
            foreach (var location in locations)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = location.Value<string>("locationId"),
                        Text = $"{location.Value<string>("city")}, {location.Value<string>("state")}"
                    });
            }
            return items;
        }

        public IEnumerable<SelectListItem> GetPrice()
        {
            var price = new List<SelectListItem>();
            price.Add(new SelectListItem()
            {
                Value = PriceFilterEnum.All.ToString(),
                Text = "All",
                Selected= true
            });

            price.Add(new SelectListItem()
            {
                Value = PriceFilterEnum.Free.ToString(),
                Text = "Free"
            });

            price.Add(new SelectListItem()
            {
                Value = PriceFilterEnum.Paid.ToString(),
                Text = "Paid"
            });
            return price;
        }

        public async Task<List<Ticket>> GetTicketsPerEvent(int EventId) 
        {
            var TicketsUri = ApiPaths.Event.GetAllTicketsForEvent(_baseUrl, EventId);
            var dataString = await _client.GetStringAsync(TicketsUri);
            return JsonConvert.DeserializeObject<List<Ticket>>(dataString);
        }


    }
}
