using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Messaging
{
    
   
    public class OrderCompletedEvent
    {
         public string BuyerId { get; set; }

        public OrderCompletedEvent(string buyerId)
        {
            BuyerId = buyerId;
        }

        public int[,] Tickets { get; set; }
        public OrderCompletedEvent(int[,] tickets)
        {
            Tickets = tickets;
        }
    }
}
