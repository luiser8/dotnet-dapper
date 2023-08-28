using dotnet_dapper.Entities;
using Dapper;

namespace dotnet_dapper.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ICommandExecuter _commandExecuter;
        public ClientRepository(ICommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
        }

        public async Task<List<Client>> GetClientsRepository()
        {
            try
            {
                var query = "SELECT * FROM Clients";
                var clients = (await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<Client>(query))).ToList();
                return clients;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Client> GetClientsByIdRepository(int clientId)
        {
            try
            {
                var query = "SELECT * FROM Clients WHERE ClientId = @ClientId";
                var sqlParams = new { ClientId = clientId };
                var client = (await _commandExecuter.ExecuteCommandAsync(connection =>
                    connection.QueryAsync<Client>(query, sqlParams))).SingleOrDefault();
                return client ?? new Client { };
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Client> CreateClientsRepository(Client client)
        {
            try
            {
                var query = "INSERT INTO Clients (ClientName, ClientEmail) VALUES(@ClientName, @ClientEmail) SELECT SCOPE_IDENTITY();";
                var sqlParams = new { client.ClientName, client.ClientEmail };
                client.ClientId = await _commandExecuter.ExecuteCommandAsync(connection => connection.ExecuteScalarAsync<int>(query, sqlParams));
                return client;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}