using BookShop.Models;
using BookShop.Repositories.Interfaces;
using BookShop.Services.Interfaces;
using IdentityModel.Client;
using Newtonsoft.Json;
using RestEase;
using System.Net.Http.Headers;
using System.Text;

namespace BookShop.Repositories
{
    public class BookRepository : IRepository<Book>
    {
//        private IHttpContextAccessor _contextAccessor;
        private HttpClient HttpClient = new HttpClient();
//        private IConfiguration _config;
        private ITokenService _tokenService;

        public BookRepository(ITokenService tokenService)
        {
//            _contextAccessor = contextAccessor;
//            _config = config;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<Book>> GetObjectListAsync()
        {
            var tokenResponce = await _tokenService.GetToken("BookAPI.read");
            HttpClient.SetBearerToken(tokenResponce.AccessToken);
//            var result = await HttpClient.GetAsync(_config["apiUrl"] + "/api/Books");
//            HttpClient.SetBearerToken(tokenResponce.AccessToken);
   //         var token = await HttpClient.GetStringAsync(tokenResponce.AccessToken);

            IRestEaseService api = RestClient.For<IRestEaseService>(Constants.Constants.APIConnectionURL);
            api.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponce.AccessToken.Trim('"'));
            var booksListJson = await api.GetList(Constants.Constants.BooksAPIController);
            var booksList = JsonConvert.DeserializeObject<List<Book>>(booksListJson);
            return booksList;
        }

        public async Task<IEnumerable<Book>> GetObjectByNameAsync(string bookname)
        {
            var tokenResponce = await _tokenService.GetToken("BookAPI.read");
            IRestEaseService api = RestClient.For<IRestEaseService>(Constants.Constants.APIConnectionURL);
            api.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponce.AccessToken.Trim('"'));
            var booksListJson = await api.GetListByName(Constants.Constants.BooksAPIController, bookname);
            var booksResult = JsonConvert.DeserializeObject<List<Book>>(booksListJson);
            return booksResult;
        }

        public async Task<IEnumerable<Book>> GetObjectByAuthorAsync(string lastname)
        {
            var tokenResponce = await _tokenService.GetToken("BookAPI.read");
            IRestEaseService api = RestClient.For<IRestEaseService>(Constants.Constants.APIConnectionURL);
            api.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponce.AccessToken.Trim('"'));
            var booksListJson = await api.GetListByAuthor(Constants.Constants.BooksAPIController, lastname);
            var booksResult = JsonConvert.DeserializeObject<List<Book>>(booksListJson);
            return booksResult;
        }

        public async Task<Book> GetObject(int id)
        {
            var tokenResponce = await _tokenService.GetToken("BookAPI.read");
            IRestEaseService api = RestClient.For<IRestEaseService>(Constants.Constants.APIConnectionURL);
            api.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponce.AccessToken.Trim('"'));
            var bookJson = await api.Get(Constants.Constants.BooksAPIController, id);
            var bookResult = JsonConvert.DeserializeObject<Book>(bookJson);
            return bookResult;
        }

        public async Task<Book> Create(Book book)
        {
            //            string token = _contextAccessor.HttpContext.Session.GetString("token");
            var tokenResponce = await _tokenService.GetToken("BookAPI.read");
            var data = new StringContent(System.Text.Json.JsonSerializer.Serialize(book), Encoding.UTF8, "application/json");
            IRestEaseService api = RestClient.For<IRestEaseService>(Constants.Constants.APIConnectionURL);
            api.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponce.AccessToken.Trim('"'));
            //            api.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
            var bookJson = await api.Post(Constants.Constants.BooksAPIController, data);
            var bookResult = JsonConvert.DeserializeObject<Book>(bookJson);
            return bookResult;
        }
    }
}
