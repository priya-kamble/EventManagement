using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Domain
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
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }

        public virtual Category Category { get; set; }
        
        //Need to uncomment these FK fields once corresponding classes are ready.
        //public virtual Location Location { get; set; }
        
        //public virtual User User { get; set; }
    }
}
