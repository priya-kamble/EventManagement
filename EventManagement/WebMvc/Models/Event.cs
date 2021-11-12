using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventImageUrl { get; set; }
        public int MaxOccupancy { get; set; }
        public int MaxTicketsPerUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPaidEvent { get; set; }
        public bool IsOnlineEvent { get; set; }
        public bool IsCancelled { get; set; }
        public string EventLinkUrl { get; set; }
        public string Address { get; set; }
        public int SubCategoryId { get; set; }
        public int UserId { get; set; }
        public int FormatId { get; set; }
        public int LocationId { get; set; }
        public string SubCategory { get; set; }
        public string User { get; set; }
        public string Format { get; set; }
        public string Location { get; set; }
    }
}
