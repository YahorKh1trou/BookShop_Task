using BookShop.Models;
using BookShop.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdermodelController : Controller
    {
        private readonly IOrderitemmodelDataAccessService<OrderItemModel[]> _orderitemService;
        private readonly IOrdermodelDataAccessService<OrderModel> _orderService;
        public OrdermodelController(IOrderitemmodelDataAccessService<OrderItemModel[]> orderitemService, IOrdermodelDataAccessService<OrderModel> orderService)
        {
            _orderitemService = orderitemService;
            _orderService = orderService;
        }

        // POST api/books
        [Route("create")]
//        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderItemModel[]>> Create([FromForm] OrderItemModel[] orderitems, [FromForm] OrderModel order)
        {
            if (orderitems == null)
                return BadRequest("No data was provided in order to create new order");

            //            await _orderService.Post(order);
            var newOrder = await _orderService.Post(order);

            for (int i = 0; i < orderitems.Length; i++)
            {
                orderitems[i].OrderId = newOrder.Id;
            }
            await _orderitemService.Post(orderitems);
            ViewData["orderMessage"] = "Товар заказан, ожидайте";

            HttpContext.Session.RemoveCart();

            return View("Index");
        }
/*
        [Route("index")]
        public async Task<ActionResult<OrderItemModel[]>> Index(OrderItemModel[] order)
        {
            if (order == null)
                return BadRequest("No data was provided in order to create new order");

            return View(await _orderService.Post(order));
        }
*/
    }
}
