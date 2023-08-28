using dotnet_dapper.Entities;
using dotnet_dapper.Requests;
using dotnet_dapper.Responses;
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
        public async Task<ActionResult<OrderResponses>> GetOrders()
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

        /// <summary>Order single</summary>
        /// <remarks>It is possible return order.</remarks>
        /// <param name="clientId" example="1">Parameters to get order.</param>
        [HttpGet("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Order>> GetOrdersById(int clientId)
        {
            try
            {
                var response = await _orderService.GetOrdersByClientIdService(clientId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Orders creation</summary>
        /// <remarks>It is possible return order creation.</remarks>
        /// <param name="order">Parameters to post order.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> PostOrders(OrderRequest order)
        {
            try
            {
                var response = await _orderService.CreateOrdersService(order);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}