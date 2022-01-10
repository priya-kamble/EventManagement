using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace OrderAPI.Models
{
    public class RegisteredTicket
    {
        public int TicketId { get; set; }
        
        public int QuantitySelected { get; set; }
       

    }
}
