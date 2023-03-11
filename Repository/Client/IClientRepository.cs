using dotnet_dapper.Entities;

namespace dotnet_dapper.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsRepository();
        Task<Client> GetClientsByIdRepository(int ClientId);
        Task<Client> CreateClients(Client client);
    }
}