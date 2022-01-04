using CartAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CartAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;
        private readonly ILogger _logger;
        public CartController(
            ICartRepository repository,
            ILogger<CartController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cart),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            var basket = await _repository.GetCartAsync(id);
            return Ok(basket);
        
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cart),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] Cart value)
        {

            var basket = await _repository.UpdateCartAsync(value);
            _logger.LogInformation(" Updating Cart...");
            _logger.LogInformation(" Updating Cart that belongs to: " + basket.UserId);
            return Ok(basket);
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            _logger.LogInformation(" Deleting Cart that belongs to: " + id);
            await _repository.DeleteCartAsync(id);
        }


    }
}
