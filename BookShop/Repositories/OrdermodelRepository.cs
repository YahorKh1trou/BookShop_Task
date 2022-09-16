using BookShop.Models;
using BookShop.Repositories.Interfaces;
using Newtonsoft.Json;
using RestEase;
using System.Text;

namespace BookShop.Repositories
{
    public class OrdermodelRepository : IOrdermodelRepository<OrderModel>
    {
        public async Task<OrderModel> Create(OrderModel order)
        {
            //            string token = _contextAccessor.HttpContext.Session.GetString("token");

            var data = new StringContent(System.Text.Json.JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");
            IRestEaseService api = RestClient.For<IRestEaseService>(Constants.Constants.APIConnectionURL);
            //            api.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim('"'));
            var orderJson = await api.PostOrder(Constants.Constants.OrderAPIController, data);
            var orderResult = JsonConvert.DeserializeObject<OrderModel>(orderJson);
            return orderResult;
        }
    }
}
