using dotnet_dapper.Entities;
using dotnet_dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(
            IOrderService orderService
        )
        {
            _orderService = orderService;
        }

        /// <summary>Orders list</summary>
        /// <remarks>It is possible return orders list.</remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetOrders()
        {
            try
            {
                var response = await _orderService.GetOrdersService();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}