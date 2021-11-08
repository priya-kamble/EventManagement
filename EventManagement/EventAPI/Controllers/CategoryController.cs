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
    public class CategoryController : ControllerBase
    {
        private readonly EventCatalogContext _Context;
        public  CategoryController(EventCatalogContext context)
        {
            _Context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Category()
        {
            var category = await _Context.Categories.ToListAsync();
            return Ok(category);
        
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SubCategory([FromQuery] int CategoryId )
        {
            var subcategory = await _Context.SubCategories.Where(s => s.CategoryId == CategoryId).ToListAsync();
            return Ok(subcategory);
        }


    }
}
