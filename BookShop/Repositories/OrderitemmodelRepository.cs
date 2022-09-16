using BookShop.Models;
using BookShop.Repositories.Interfaces;
using Newtonsoft.Json;
using RestEase;
using System.Text;

namespace BookShop.Repositories
{
    public class OrderitemmodelRepository : IOrderitemmodelRepository<OrderItemModel[]>
    {
        public async Task<OrderItemModel[]> Create(OrderItemModel[] orderitems)
        {
            //            string token = _contextAccessor.HttpContext.Session.GetString("token");

            var data = new StringContent(System.Text.Json.JsonSerializer.Serialize(orderitems), Encoding.UTF8, "application/json");
            IRestEaseService api = RestClient.For<IRestEaseService>(Constants.Constants.APIConnectionURL);
            //            api.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
            var orderJson = await api.Post(Constants.Constants.OrderitemAPIController, data);
            var orderResult = JsonConvert.DeserializeObject<OrderItemModel[]>(orderJson);
            return orderResult;
        }
    }
}
