using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
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
        Task<EventDetails> GetEventDetails(int EventId);
        Task<List<Ticket>> GetTicketsPerEvent(int EventId);
     //   Task UpdateTicketsQuantity(List<Ticket> tickets);
    }
}
