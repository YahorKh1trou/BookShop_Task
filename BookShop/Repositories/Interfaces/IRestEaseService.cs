using RestEase;
using System.Net.Http.Headers;

namespace BookShop.Repositories.Interfaces
{
    public interface IRestEaseService
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

//        [AllowAnyStatusCode]
        [Get("api/{path}")]
        Task<string> GetList([Path] string path);

//        [AllowAnyStatusCode]
        [Get("api/{path}/{bookname}")]
        Task<string> GetListByName([Path] string path, [Path] string bookname);

//        [AllowAnyStatusCode]
        [Get("api/{path}/{lastname}")]
        Task<string> GetListByAuthor([Path] string path, [Path] string lastname);

//        [AllowAnyStatusCode]
        [Get("api/{path}/{id}")]
        Task<string> Get([Path] string path, [Path] int id);

        [Post("api/{path}")]
        Task<string> Post([Path] string path, [Body] object obj);

        [Post("api/{path}")]
        Task<string> PostOrder([Path] string path, [Body] object obj);
    }
}
