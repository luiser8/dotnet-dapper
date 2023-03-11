using dotnet_dapper.Entities;

namespace dotnet_dapper.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersService();
        Task<Order> CreateOrders(Order order);
    }
}