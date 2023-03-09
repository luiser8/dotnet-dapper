using dotnet_dapper.Entities;
using dotnet_dapper.Repository;

namespace dotnet_dapper.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Order>> GetOrdersService()
        {
            try
            {
                return _orderRepository.GetOrdersRepository();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}