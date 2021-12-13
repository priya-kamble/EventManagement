using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.ViewModels
{
    public class CartComponentViewModel
    {
        public int TicketsInCart { get; set; }
        public decimal TotalCost { get; set; }
        public string Disabled => (TicketsInCart == 0) ? "is-disabled" : ""; 
    }
}
