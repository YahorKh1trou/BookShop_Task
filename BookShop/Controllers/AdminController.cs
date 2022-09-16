using BookShop.Models;
using BookShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDataAccessService<Book> _bookService;
        public AdminController(IDataAccessService<Book> bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] string name, [FromForm] string lastname, [FromForm] string patro, [FromForm] string birthdate,
            [FromForm] string bookname, [FromForm] int year, [FromForm] int price)
        {
            Book book = new Book()
            {
                Name = name,
                Lastname = lastname,
                Patro = patro,
                Birthdate = birthdate,
                Bookname = bookname,
                Year = year,
                Price = price,
            };
            await _bookService.Post(book);
            ViewData["addMessage"] = "Товар добавлен";
            return View("AddResult");
        }
        public IActionResult AddResult()
        {
            return View();
        }
    }
}
