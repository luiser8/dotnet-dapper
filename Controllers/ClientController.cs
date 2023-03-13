using dotnet_dapper.Entities;
using dotnet_dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(
            IClientService clientService
        )
        {
            _clientService = clientService;
        }

        /// <summary>Clients list</summary>
        /// <remarks>It is possible return clients list.</remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Client>> GetClients()
        {
            try
            {
                var response = await _clientService.GetClientsService();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Client single</summary>
        /// <remarks>It is possible return client.</remarks>
        /// <param name="clientId" example="1">Parameters to get client.</param>
        [HttpGet("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Client>> GetClientsById(int clientId)
        {
            try
            {
                var response = await _clientService.GetClientsByIdService(clientId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Clients creation</summary>
        /// <remarks>It is possible return client creation.</remarks>
        /// <param name="client">Parameters to post client.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Client>> PostClients(Client client)
        {
            try
            {
                var response = await _clientService.CreateClientsService(client);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}