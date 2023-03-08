using dotnet_dapper.Entities;

namespace dotnet_dapper.Repository
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {

        }
        public async Task<List<string>> GetProductsRepository()
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