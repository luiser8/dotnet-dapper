using dotnet_dapper.Entities;

namespace dotnet_dapper.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsRepository();
        Task<Product> GetProductsByIdRepository(int productId);
        Task<Product> CreateProductsRepository(Product product);
    }
}