using BookShop.Models;
using BookShop.Repositories.Interfaces;
using BookShop.Services.Interfaces;

namespace BookShop.Services
{
    public class BookDataAccessService : IDataAccessService<Book>
    {
        private readonly IRepository<Book> _bookRepository;
        public BookDataAccessService(IRepository<Book> repository)
        {
            _bookRepository = repository;
        }
        public async Task<IEnumerable<Book>> Get(string bookname)
        {
            return await _bookRepository.GetObjectByNameAsync(bookname);
        }
        public async Task<IEnumerable<Book>> GetList()
        {
            return await _bookRepository.GetObjectListAsync();
        }

        public async Task<IEnumerable<Book>> GetListByAuthor(string lastname)
        {
            return await _bookRepository.GetObjectByAuthorAsync(lastname);
        }

        public async Task<Book> Get(int id)
        {
            return await _bookRepository.GetObject(id);
        }

        public async Task<Book> Post(Book book)
        {
            return await _bookRepository.Create(book);
        }

        public async Task<string> GetSingleBook(int id)
        {
            var book = await _bookRepository.GetObject(id);
//            return await _bookRepository.GetObject(id);
            return book.Lastname;
        }
    }
}
