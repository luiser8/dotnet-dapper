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
    }
}