using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebMvc.Models
{
    public class Ticket
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

        public IEnumerable<SelectListItem> AvailableTicketsQuantity { get; set; }
        public string QuantitySelected { get; set; }
        
        public string TicketStatus { get; set; }

    }

}
