using BookShop.Models;
using BookShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IDataAccessService<Book> _bookService;

        public QuoteController(IDataAccessService<Book> bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var result = await _bookService.Get(id);
            return View(result);
        }
    }
}
