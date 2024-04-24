using factoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(
            string ProductName,
            string ProductDescription,
            int ProductStatusId,
            int ProductionLineId)
        {
            var product = await _productService.AddProduct(
                               ProductName,
                                              ProductDescription,
                                              ProductStatusId,
                                              ProductionLineId);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(
            int ProductId,
            string? ProductName,
            string? ProductDescription,
            int? ProductStatusId,
            int? ProductionLineId)
        {
            var product = await _productService.UpdateProduct(
                ProductId,
                ProductName,
                ProductDescription,
                ProductStatusId,
                ProductionLineId);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.DeleteProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}
