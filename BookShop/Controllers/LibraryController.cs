using BookShop.Models;
using BookShop.Services.Interfaces;
using BookShop.ViewModels;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookShop.Controllers
{
    //    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly IDataAccessService<Book> _bookService;
//        private static ObservableCollection<LibraryModel> library;
        private static IEnumerable<Book> allBooks;
        public LibraryController(IDataAccessService<Book> bookService)
        {
            _bookService = bookService;
        }

        [Route("index")]
        public async Task<IActionResult> Index()
        {
            allBooks = await _bookService.GetList();
            var dislibrary = allBooks.GroupBy(i => i.Lastname).Select(grp => grp.First());
            ViewData["AuthorDropdown"] = new SelectList(dislibrary.ToList(), "Id", "Lastname");
            return View(allBooks);
        }
    }
}
