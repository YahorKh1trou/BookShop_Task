using BookShop.Models;
using BookShop.Repositories.Interfaces;
using BookShop.Services.Interfaces;

namespace BookShop.Services
{
    public class OrdermodelDataAccessService : IOrdermodelDataAccessService<OrderModel>
    {
        private readonly IOrdermodelRepository<OrderModel> _orderRepository;
        public OrdermodelDataAccessService(IOrdermodelRepository<OrderModel> repository)
        {
            _orderRepository = (IOrdermodelRepository<OrderModel>?)repository;
        }

        public async Task<OrderModel> Post(OrderModel order)
        {
            return await _orderRepository.Create(order);
        }
    }
}
