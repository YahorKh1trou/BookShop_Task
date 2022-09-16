using BookShop.Models;
using BookShop.Repositories.Interfaces;
using BookShop.Services.Interfaces;

namespace BookShop.Services
{
    public class OrderitemmodelDataAccessService : IOrderitemmodelDataAccessService<OrderItemModel[]>
    {
        private readonly IOrderitemmodelRepository<OrderItemModel[]> _orderRepository;
        public OrderitemmodelDataAccessService(IOrderitemmodelRepository<OrderItemModel[]> repository)
        {
            _orderRepository = (IOrderitemmodelRepository<OrderItemModel[]>?)repository;
        }

        public async Task<OrderItemModel[]> Post(OrderItemModel[] orderitems)
        {
            return await _orderRepository.Create(orderitems);
        }
    }
}
