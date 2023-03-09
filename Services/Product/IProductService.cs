using dotnet_dapper.Entities;

namespace dotnet_dapper.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsService();
    }
}