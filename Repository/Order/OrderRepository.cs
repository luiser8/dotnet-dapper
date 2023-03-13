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

        public async Task<Order> GetOrdersByIdRepository(int orderId)
        {
            try
            {
                var query = "SELECT * FROM Orders WHERE OrderId = @OrderId";
                var sqlParams = new { OrderId = orderId };
                var order = (await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<Order>(query, sqlParams))).SingleOrDefault();
                return order ?? new Order {};
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Order> CreateOrdersRepository(Order order)
        {
            try
            {
                var query = @"INSERT INTO Orders (ClientId, ProductId)
                                VALUES(@ClientId, @ProductId) SELECT SCOPE_IDENTITY();";
                var sqlParams = new { ClientId = order.ClientId, ProductId = order.ProductId };
                order.OrderId = await _commandExecuter.ExecuteCommandAsync(connection => connection.ExecuteScalarAsync<int>(query, sqlParams));
                return order;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}