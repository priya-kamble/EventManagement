using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models.OrderModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string EventTitle { get; set; }
        public string TicketCategoryName { get; set; }
        public DateTime EventSelectedDate { get; set; }
        public decimal TicketPrice { get; set; }
        public int TicketQuantity { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
