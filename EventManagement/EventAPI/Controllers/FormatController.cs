using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly EventCatalogContext _context;

        public FormatController(EventCatalogContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> Format()
        {
            var format = await _context.Formats.ToListAsync();
            return Ok(format);
        }


    }
}