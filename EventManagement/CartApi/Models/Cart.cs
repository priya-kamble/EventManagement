using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Models
{
    public class Cart
    {
        public string UserId { get; set; }
        public List<CartItem> Tickets { get; set; }
        public Cart()
        {

        }
        public Cart(string cartId)
        {
            UserId = cartId;
            Tickets = new List<CartItem>();
        }
    }
}
