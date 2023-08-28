using dotnet_dapper.Entities;

namespace dotnet_dapper.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetClientsService();
        Task<Client> GetClientsByIdService(int clientId);
        Task<Client> CreateClientsService(Client client);
    }
}