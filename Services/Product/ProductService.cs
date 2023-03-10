using dotnet_dapper.Entities;
using dotnet_dapper.Repository;

namespace dotnet_dapper.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> GetProductsService()
        {
            try
            {
                return _productRepository.GetProductsRepository();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Product> CreateProducts(Product product)
        {
            try
            {
                return _productRepository.CreateProducts(product);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}