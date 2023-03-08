using dotnet_dapper.Entities;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace dotnet_dapper.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;
        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Client>> GetClientsRepository()
        {
            try
            {
                var query = "SELECT * FROM Clients";
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                using(var connection = new SqlConnection(connectionString))
                {
                    return (List<Client>)await connection.QueryAsync<Client>(query);
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}