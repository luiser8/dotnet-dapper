using dotnet_dapper.Requests;
using dotnet_dapper.Responses;

namespace dotnet_dapper.Services
{
    public interface IOrderService
    {
        Task<List<OrderResponses>> GetOrdersService();
        Task<List<OrderResponses>> GetOrdersByClientIdService(int ClientId);
        Task<int> CreateOrdersService(OrderRequest order);
    }
}