using System.Text.Json;
using Dapper;
using dotnet_dapper.Requests;
using dotnet_dapper.Responses;

namespace dotnet_dapper.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ICommandExecuter _commandExecuter;
        public OrderRepository(ICommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
        }
        public async Task<List<OrderResponses>> GetOrdersRepository()
        {
            try
            {
                var query = @"SELECT OrderId
                                ,ClientId
                                ,OrderStatus
                                ,OrderTotal
                                ,OrderCreation
                            FROM Orders";
                var order = await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<OrderResponses>(query));

                return (List<OrderResponses>)order;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<List<OrderResponses>> GetOrdersByClientIdRepository(int? ClientId)
        {
            try
            {
                var query = @"SELECT OrderId
                                ,ClientId
                                ,OrderStatus
                                ,OrderTotal
                                ,OrderCreation
                            FROM Orders WHERE ClientId = IsNull(@ClientId, ClientId)";
                var order = await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<OrderResponses>(query, new { ClientId }));

                return (List<OrderResponses>)order;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> CreateOrdersRepository(OrderRequest order)
        {
            try
            {
                var queryOrder = @"INSERT INTO Orders (ClientId, OrderStatus, OrderTotal)
                                VALUES(@ClientId, @OrderStatus, @OrderTotal) SELECT SCOPE_IDENTITY();";
                var sqlParams = new { order.ClientId, OrderStatus = 1, order.OrderTotal };
                int OrderId = await _commandExecuter.ExecuteCommandAsync(connection => connection.ExecuteScalarAsync<int>(queryOrder, sqlParams));

                return OrderId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}