using Dapper;
using dotnet_dapper.Requests;
using dotnet_dapper.Responses;

namespace dotnet_dapper.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly ICommandExecuter _commandExecuter;
        public OrderProductRepository(ICommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
        }
        public async Task<int> CreateOrderProductsRepository(OrderProductsRequest orderProductsRequest, int OrderId)
        {
            try
            {
                var queryOrderProduct = @"INSERT INTO OrderProducts (OrderId, ProductId, ProductQuantity, OrderProductTotal, OrderProductStatus)
                                VALUES(@OrderId, @ProductId, @ProductQuantity, @OrderProductTotal, @OrderProductStatus)";
                var sqlParams = new { OrderId, orderProductsRequest.ProductId, orderProductsRequest.ProductQuantity, orderProductsRequest.OrderProductTotal, OrderProductStatus = 1 };
                var orderProductId = await _commandExecuter.ExecuteCommandAsync(connection => connection.ExecuteScalarAsync<int>(queryOrderProduct, sqlParams));

                return orderProductId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<List<ProductsOrderResponses>> GetOrderProductsRepository(int OrderId)
        {
            try
            {
                var query = @"SELECT op.OrderProductId
                            ,op.ProductId
                            ,p.ProductName
                            ,op.ProductQuantity
                            ,op.OrderProductTotal
                            ,op.OrderProductStatus
                            ,op.OrderProductCreation
                        FROM OrderProducts op
                        INNER JOIN Products p ON p.ProductId = op.ProductId WHERE op.OrderId = @OrderId";
                var orderProducts = await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<ProductsOrderResponses>(query, new { OrderId }));

                return (List<ProductsOrderResponses>)orderProducts;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
