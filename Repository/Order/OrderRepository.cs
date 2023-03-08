using dotnet_dapper.Entities;

namespace dotnet_dapper.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository()
        {

        }
        public async Task<List<string>> GetOrdersRepository()
        {
            try
            {
                return new List<string>();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}