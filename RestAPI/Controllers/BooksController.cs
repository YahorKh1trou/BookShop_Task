using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Counters;
using RestAPI.Models;
using RestAPI.ViewModels;
using Services.CustomExceptions;
using Services.Services.Contracts;
using System.Security.Claims;

namespace RestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var domainBooks = await _booksService.GetAsync();
            return Ok(domainBooks.Select(x => new Book(x)));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _booksService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(new Book(book));
        }

        //        [HttpGet("get/{name}")]
        [HttpGet("get/{bookname}")]
//        [HttpGet("{bookname:alpha}")]
        public async Task<ActionResult<IEnumerable<Book>>> Get(string bookname)
        {
            var domainBooks = await _booksService.GetByNameAsync(bookname);
            return Ok(domainBooks.Select(x => new Book(x)));
        }

//        [Authorize(Policy = "admin")]
        [HttpGet("{lastname:alpha}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAuthor(string lastname)
        {
//            var userRole = HttpContext.User.FindFirst("client_Role").ToString();
            var domainBooks = await _booksService.GetByAuthorAsync(lastname);
            return Ok(domainBooks.Select(x => new Book(x)));
        }

        [Authorize(Policy = "admin")]
        // POST api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Post(AddBookViewModel addBook)
        {
            if (addBook == null || !addBook.Validate())
            {
                return BadRequest();
            }

            var newBook = await _booksService.AddBookAsync(addBook.ToDomainBook(addBook));
            //            var domainBooks = await _booksService.GetAsync();
            //            book.Id = domainBooks.Max(p => p.Id);
            var book = new Book(newBook);

            AddCounter Counter = AddCounter.Initialize();
            book.Counter = Counter.Increment();

//            book.Price = 30;

            return Ok(book);
        }
        // PUT api/books/
        [HttpPut]
        public async Task<ActionResult<Book>> Put(UpdateBookViewModel book)
        {
            if (book == null || !book.Validate())
            {
                return BadRequest();
            }
            await _booksService.UpdateBookAsync(book.ToDomainBook(book));
            return Ok(book);
        }

        // DELETE api/books/5
        [Authorize(Policy = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _booksService.DeleteBookAsync(id);
                return Ok(book);
            }
            catch(Exception ex)
            {
                if(ex is BookNotFoundException bookException)
                {
                    return NotFound(bookException.Message);
                }
                return StatusCode(500);
            }
        }
    }
}
