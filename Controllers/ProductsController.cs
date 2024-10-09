using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using VanceSampleApi.Models;
using VanceSampleApi.Repositories.Interfaces;

namespace VanceSampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _repository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            return product == null ? 
                (ActionResult<Product>) NotFound() : 
                (ActionResult<Product>) Ok(product);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _repository.AddProductAsync(product);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result = await _repository.UpdateProductAsync(product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _repository.DeleteProductAsync(id);
            return Ok();
        }
    }
}
