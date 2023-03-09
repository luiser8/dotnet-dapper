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

        /// <summary>Clients creation</summary>
        /// <remarks>It is possible return client creation.</remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Client>> PostClients(Client client)
        {
            try
            {
                var response = await _clientService.CreateClients(client);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}