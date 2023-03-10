using dotnet_dapper.Entities;
using dotnet_dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(
            IProductService productService
        )
        {
            _productService = productService;
        }

        /// <summary>Products list</summary>
        /// <remarks>It is possible return products list.</remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> GetProducts()
        {
            try
            {
                var response = await _productService.GetProductsService();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Products creation</summary>
        /// <remarks>It is possible return product creation.</remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Product>> PostProducts(Product client)
        {
            try
            {
                var response = await _productService.CreateProducts(client);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}