using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models.CartModels
{
    public class Cart
    {
        public string UserId { get; set; }
        public List<CartItem> Tickets { get; set; } = new List<CartItem>();
   
        public decimal Total()
        {
            return Math.Round(Tickets.Sum(x => x.TicketPrice * x.Quantity), 2);
        }

    }
}
