using dotnet_dapper.Entities;

namespace dotnet_dapper.Repository
{
    public interface IOrderRepository
    {
        Task<List<string>> GetOrdersRepository();
    }
}