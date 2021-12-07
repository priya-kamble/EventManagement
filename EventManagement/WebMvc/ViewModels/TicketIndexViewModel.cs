using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class TicketIndexViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }
        public DateTime DateSelected { get; set; }

    }
}
