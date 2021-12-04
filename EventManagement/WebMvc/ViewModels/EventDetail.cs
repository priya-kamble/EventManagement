﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.ViewModels
{
    public class EventDetails
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
        public int SubCategoryName { get; set; }
        public string FormatName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> AvailableDates { get; set; }
        public string DateSelected { get; set; }

    }
}
