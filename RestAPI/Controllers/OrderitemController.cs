using Data.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Contracts;

namespace RestAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class OrderitemController : ControllerBase
        {
            private readonly IOrderItemService _ordersService;

            public OrderitemController(IOrderItemService ordersService)
            {
                _ordersService = ordersService;
            }
            // POST api/values
            [HttpPost]
            public async Task<ActionResult<OrderItem[]>> Post(OrderItem[] addOrderItems)
            {
                if (addOrderItems == null)
                {
                    return BadRequest();
                }

                var newOrderItems = await _ordersService.AddOrderItemsAsync(addOrderItems);
                return Ok(newOrderItems);
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult<OrderItem>> Get(int id)
            {
                var order = await _ordersService.GetOrderByIdAsync(id);
                if (order == null)
                    return NotFound();
                return Ok(order);
            }
        }
}
