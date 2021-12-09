using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models.CartModels
{
    public class Cart
    {
        public string UserId { get; set; }
        public List<CartItem> CartTickets { get; set; } = new List<CartItem>();
   
        public decimal Total()
        {
            return Math.Round(CartTickets.Sum(x => x.TicketPrice * x.Quantity), 2);
        }

    }
}
