
using EventAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Messaging
{
    public class OrderTicketmessage
    {
        //public int[,] Tickets { get; set; }
        //public OrderTicketmessage(int[,] tickets)
        //{
        //    Tickets = tickets;
        //}
        public List<RegisteredTicket> RegisteredTickets { get; set; }
        public OrderTicketmessage(List<RegisteredTicket> tickets)
        {
            RegisteredTickets = tickets;
        }
    }
}
