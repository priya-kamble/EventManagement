using EventAPI.Domain;
using System;

namespace EventAPI.ViewModel
{
    public class TicketDetailViewModel
    {
        public int TicketId { get; set; }
        public int TicketCategoryId { get; set; }

        public decimal Price { get; set; }
        public DateTime SalesStartDate { get; set; }
        public DateTime SalesEndDate { get; set; }
        public int Quantity { get; set; }
        public int EventId { get; set; }

        public TicketCategory TicketCategory { get; set; }
        public Event Event { get; set; }
    }
}
