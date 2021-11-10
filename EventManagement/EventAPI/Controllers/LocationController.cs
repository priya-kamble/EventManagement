using EventAPI.Data;
using EventAPI.Domain;
using EventAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public readonly EventCatalogContext _context;
        public LocationController(EventCatalogContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Cities()
        {
            var locations = await _context.Locations.ToListAsync();
            var cities = new List<string>();
            foreach (var location in locations)
            {
                if (!cities.Contains(location.City))
                    cities.Add(location.City);
            }
            return Ok(cities);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> States()
        {
            var locations = await _context.Locations.ToListAsync();
            var states = new List<string>();
            foreach (var location in locations)
            {
                if (!states.Contains(location.State))
                states.Add(location.State);
            }
            return Ok(states);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Locations()
        {
            var locations = await _context.Locations.ToListAsync();
            return Ok(locations);
        }
    }
}
