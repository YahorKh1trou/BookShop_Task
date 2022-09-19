using BookShop.Middlewares;
using BookShop.Models;
using BookShop.Repositories.Interfaces;
using BookShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IDataAccessService<Book> _bookService;
        private readonly IOrderRepository _orderRepository;
        public OrderController(IDataAccessService<Book> bookService, IOrderRepository orderRepository)
        {
            _bookService = bookService;
            _orderRepository = orderRepository;
        }

        private async Task<OrderModel> Map(Order order)
        {
            var bookIds = order.Items.Select(item => item.BookId);
            var allBooks = await _bookService.GetList(); //плохо, нужно будет переделать на уровне data

            // all linq query should be written on one style, prefere extensions
            var foundBooks = from book in allBooks
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            var itemModels = from item in order.Items
                             join book in foundBooks on item.BookId equals book.Id
                             select new OrderItemModel
                             {
                                 BookId = book.Id,
                                 Bookname = book.Bookname,
                                 Lastname = book.Lastname,
                                 Count = item.Count,
                                 Price = item.Price,
                             };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = _orderRepository.GetById(cart.OrderId);
                OrderModel model = await Map(order);

                return View(model);
            }
            return View("Empty");
        }

        public async Task<IActionResult> AddItem(int id)
        {
            Order order;
            Cart cart;

            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = _orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = _orderRepository.Create();
                cart = new Cart(order.Id);
            }
            var book = await _bookService.Get(id);
            order.AddItem(book, 1);
            _orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
/*
                cart = new Cart();
            if (cart.Items.ContainsKey(id))
                cart.Items[id]++;
            else
                cart.Items[id] = 1;
            cart.Amount += book.Price;
*/
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Quote", new { id });
        }
    }
}
