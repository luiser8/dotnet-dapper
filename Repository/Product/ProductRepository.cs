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

        public async Task<Product> CreateProducts(Product product)
        {
            try
            {
                var query = @"INSERT INTO Products (ProductName, ProductDesc, ProductPrice)
                                VALUES(@ProductName, @ProductDesc, @ProductPrice) SELECT SCOPE_IDENTITY();";
                var sqlParams = new { ProductName = product.ProductName, ProductDesc = product.ProductDesc, ProductPrice = product.ProductPrice };
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