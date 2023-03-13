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

        /// <summary>Product single</summary>
        /// <remarks>It is possible return product.</remarks>
        /// <param name="productId" example="1">Parameters to get product.</param>
        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Product>> GetProductsById(int productId)
        {
            try
            {
                var response = await _productService.GetProductsByIdService(productId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>Products creation</summary>
        /// <remarks>It is possible return product creation.</remarks>
        /// <param name="product">Parameters to post product.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Product>> PostProducts(Product product)
        {
            try
            {
                var response = await _productService.CreateProductsService(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}