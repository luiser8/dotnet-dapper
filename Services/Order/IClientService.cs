using dotnet_dapper.Entities;

namespace dotnet_dapper.Services
{
    public interface IOrderService
    {
        Task<List<string>> GetOrdersService();
    }
}