using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Models
{
    public class Cart
    {
        public string UserId { get; set; }
        public List<CartItem> CardTickets { get; set; } = new List<CartItem>();
   
        public decimal Total()
        {
            return Math.Round(CardTickets.Sum(x => x.TicketPrice * x.Quantity), 2);
        }

    }
}
