using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models.CartModels
{
    public class CartItem
    {
        public string CartItemId { get; set; }
        public string TicketId { get; set; }
        public string TicketCategoryName { get; set; }
        public DateTime UserSelectedDate { get; set; }
        public decimal TicketPrice { get; set; }
        public int Quantity { get; set; }
        public string EventTitle { get; set; }
        public string EventId { get; set; }
    }
}
