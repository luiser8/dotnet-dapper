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

        /// <summary>Order single</summary>
        /// <remarks>It is possible return order.</remarks>
        /// <param name="orderId" example="1">Parameters to get order.</param>
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Order>> GetOrdersById(int orderId)
        {
            try
            {
                var response = await _orderService.GetOrdersByIdService(orderId);
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
        public async Task<ActionResult<Order>> PostOrders(Order order)
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