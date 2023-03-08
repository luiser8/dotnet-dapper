using dotnet_dapper.Entities;

namespace dotnet_dapper.Repository
{
    public interface IProductRepository
    {
        Task<List<string>> GetProductsRepository();
    }
}