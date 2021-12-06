using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class TicketIndexViewModel
    {
        public IEnumerable<Ticket> TicketsForEvent { get; set; }
        public string DateSelected { get; set; }

    }
}
