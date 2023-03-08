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
    }
}