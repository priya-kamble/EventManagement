using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebMvc.Models.OrderModels
{
    public enum OrderStatus
    {
        Preparing = 1,
        Shipped = 2,
        Delivered = 3,
    }
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [BindNever]
        public DateTime OrderDate { get; set; }

        [BindNever]
        public string BuyerId { get; set; }

        [BindNever]
        public string UserName { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [Required]
        public string Address { get; set; }

       
        public string PaymentAuthCode { get; set; }
        public string StripeToken { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal OrderTotal { get; set; }

        public List<OrderItem> OrderItems { get; } = new List<OrderItem>();


    }
}
