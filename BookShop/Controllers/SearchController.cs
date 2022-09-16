using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using IdentityModel.Client;
using BookShop.Services.Interfaces;

namespace BookShop.Controllers
{
    public class SearchController : Controller
    {
        private ITokenService _tokenService;

        public SearchController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public async Task<IActionResult> Index(string query)
        {
            var tokenResponce = await _tokenService.GetToken("BookAPI.read");
            IEnumerable<Book> books = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponce.AccessToken.Trim('"'));
                client.BaseAddress = new Uri("https://localhost:7032/api/");
                var responseTask = client.GetAsync($"books/get/{query}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<Book>>();
                    readJob.Wait();
                    books = readJob.Result;
                }
                else
                {
                    books = Enumerable.Empty<Book>();
                    ModelState.AddModelError(string.Empty, "Server error occured. Please contact admin for help!");
                }
            }
            return View(books);
        }
    }
}
