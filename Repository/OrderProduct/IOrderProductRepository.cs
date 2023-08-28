using dotnet_dapper.Entities;
using dotnet_dapper.Requests;
using dotnet_dapper.Responses;

namespace dotnet_dapper.Repository
{
    public interface IOrderProductRepository
    {
        Task<List<ProductsOrderResponses>> GetOrderProductsRepository(int OrderId);
        Task<int> CreateOrderProductsRepository(OrderProductsRequest orderProductsRequest, int OrderId);
    }
}