using Data.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Contracts;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _ordersService;

        public OrderController(IOrderService ordersService)
        {
            _ordersService = ordersService;
        }
        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order addOrder)
        {
            if (addOrder == null)
            {
                return BadRequest();
            }

            var newOrder = await _ordersService.AddOrderAsync(addOrder);
            return Ok(newOrder);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var order = await _ordersService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }
    }
}
