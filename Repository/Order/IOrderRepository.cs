using dotnet_dapper.Entities;
using dotnet_dapper.Requests;
using dotnet_dapper.Responses;

namespace dotnet_dapper.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderResponses>> GetOrdersRepository();
        Task<List<OrderResponses>> GetOrdersByClientIdRepository(int? ClientId);
        Task<int> CreateOrdersRepository(OrderRequest order);
    }
}