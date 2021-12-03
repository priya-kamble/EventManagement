using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface IEventService
    {
        Task<PaginatedEvents> GetEventsAsync(
                                        int page,
                                        int size,
                                        DateTime? startDate,
                                        DateTime? endDate,
                                        //string city,
                                        //string state,
                                        int? categoryId,
                                        int? formatId,
                                        int? locationId,
                                        bool? isOnline,
                                        bool? isPaid);
        Task<IEnumerable<SelectListItem>> GetFormatAsync();
        Task<IEnumerable<SelectListItem>> GetLocationsAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        IEnumerable<SelectListItem> GetDates();
        IEnumerable<SelectListItem> GetPrice();

        // Temporary method for development only:
        Task<Event> GetEventDetails(int EventId);

    }
}
