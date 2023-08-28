using dotnet_dapper.Entities;
using dotnet_dapper.Repository;

namespace dotnet_dapper.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<List<Client>> GetClientsService()
        {
            try
            {
                return _clientRepository.GetClientsRepository();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Client> GetClientsByIdService(int clientId)
        {
            try
            {
                return _clientRepository.GetClientsByIdRepository(clientId);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public Task<Client> CreateClientsService(Client client)
        {
            try
            {
                return _clientRepository.CreateClientsRepository(client);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}