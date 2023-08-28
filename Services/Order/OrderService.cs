using dotnet_dapper.Repository;
using dotnet_dapper.Requests;
using dotnet_dapper.Responses;

namespace dotnet_dapper.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductsRepository;
        public OrderService(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository)
        {
            _orderRepository = orderRepository;
            _orderProductsRepository = orderProductRepository;
        }

        public async Task<List<OrderResponses>> GetOrdersService()
        {
            try
            {
                var orders = await _orderRepository.GetOrdersRepository();
                foreach (var item in orders)
                {
                    var orderProducts = await _orderProductsRepository.GetOrderProductsRepository(item.OrderId);
                    item.Products = orderProducts;
                }

                return orders;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<List<OrderResponses>> GetOrdersByClientIdService(int clientId)
        {
            try
            {
                var orders = await _orderRepository.GetOrdersByClientIdRepository(clientId);
                foreach (var item in orders)
                {
                    var orderProducts = await _orderProductsRepository.GetOrderProductsRepository(item.OrderId);
                    item.Products = orderProducts;
                }

                return orders;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
        public async Task<int> CreateOrdersService(OrderRequest order)
        {
            try
            {
                int orderId = await _orderRepository.CreateOrdersRepository(order);
                if (orderId != 0)
                {
                    foreach (var item in order.Products)
                    {
                        await _orderProductsRepository.CreateOrderProductsRepository(item, orderId);
                    }
                }
                return orderId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}