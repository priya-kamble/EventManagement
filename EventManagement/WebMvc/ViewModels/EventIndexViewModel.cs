using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventIndexViewModel
    {
        public IEnumerable<SelectListItem> Location { get; set; }
        public IEnumerable<SelectListItem> Format { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<SelectListItem> Date { get; set; }
        public IEnumerable<SelectListItem> Price { get; set; }
        public bool? Online { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public PaginationInfo PaginationInfo { get; set; }

        public int? LocationFilterApplied { get; set; }
        public int? FormatFilterApplied { get; set; }
        public int? CategoryFilterApplied { get; set; }
        public string DateFilterApplied { get; set; }
        public string PriceFilterApplied { get; set; }
        public bool? OnlineFilterApplied { get; set; }
    }
}
