using Dapper;
using dotnet_dapper.Entities;

namespace dotnet_dapper.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ICommandExecuter _commandExecuter;
        public OrderRepository(ICommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
        }
        public async Task<List<Order>> GetOrdersRepository()
        {
            try
            {
                var query = "SELECT * FROM Orders";
                var products = (await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<Order>(query))).ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}