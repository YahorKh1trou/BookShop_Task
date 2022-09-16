using BookShop.Models;
using BookShop.Services.Interfaces;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace BookShop.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IDataAccessService<Book> _bookService;
        //        private static ObservableCollection<LibraryModel> library;
        private static IEnumerable<Book> allBooksByAuthor;
        public AuthorController(IDataAccessService<Book> bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index(string lastname, int authors)
        {
            lastname = await _bookService.GetSingleBook(authors);
            allBooksByAuthor = await _bookService.GetListByAuthor(lastname);
            return View(allBooksByAuthor);
        }
    }
}
