using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Domain
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int TicketCategoryId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime SalesStartDate { get; set; }
        public DateTime SalesEndDate { get; set; }
        public int Quantity { get; set; }
        public int EventId { get; set; }

        public virtual TicketCategory TicketCategory { get; set; }
        public virtual Event Event { get; set; }
    }
}
