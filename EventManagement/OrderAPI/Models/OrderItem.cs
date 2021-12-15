using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.Infrastructure.Exceptions;

namespace OrderAPI.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string EventTitle { get; set; }
        public string TicketCategoryName { get; set; }
        public DateTime EventSelectedDate { get; set; }
        public decimal TicketPrice { get; set; }
        public int TicketQuantity { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }


        public OrderItem(int ticketId,string eventTitle,string ticketCategoryName,DateTime eventSelectedDate,decimal ticketPrice, int ticketQuantity=1)
        {
            if (TicketQuantity <= 0)
            {
                throw new OrderingDomainException("Invalid number Of tickets");
            }

            TicketId = ticketId;
            EventTitle = eventTitle;
            TicketCategoryName = ticketCategoryName;
            EventSelectedDate = eventSelectedDate;
            TicketPrice = ticketPrice;
            TicketQuantity = ticketQuantity;
        }

        public void AddTicketQuantity(int ticketQuantity)
        {
            if (ticketQuantity < 0)
            {
                throw new OrderingDomainException("Invalid units");
            }

            ticketQuantity += ticketQuantity;

        }





    }
}
