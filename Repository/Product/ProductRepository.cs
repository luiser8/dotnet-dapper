using Dapper;
using dotnet_dapper.Entities;

namespace dotnet_dapper.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICommandExecuter _commandExecuter;
        public ProductRepository(ICommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
        }
        public async Task<List<Product>> GetProductsRepository()
        {
            try
            {
                var query = "SELECT * FROM Products";
                var products = (await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<Product>(query))).ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Product> GetProductsByIdRepository(int productId)
        {
            try
            {
                var query = "SELECT * FROM Products WHERE ProductId = @ProductId";
                var sqlParams = new { ProductId = productId };
                var product = (await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<Product>(query, sqlParams))).SingleOrDefault();
                return product ?? new Product { };
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Product> CreateProductsRepository(Product product)
        {
            try
            {
                var query = @"INSERT INTO Products (ProductName, ProductDesc, ProductPrice, ProductQuantity)
                                VALUES(@ProductName, @ProductDesc, @ProductPrice, @ProductQuantity) SELECT SCOPE_IDENTITY();";
                var sqlParams = new { product.ProductName, product.ProductDesc, product.ProductPrice, product.ProductQuantity };
                product.ProductId = await _commandExecuter.ExecuteCommandAsync(connection => connection.ExecuteScalarAsync<int>(query, sqlParams));
                return product;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}