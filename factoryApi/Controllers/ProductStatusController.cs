using factoryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductStatusController : ControllerBase
    {

        private readonly IProductStatusService _productStatusService;

        public ProductStatusController(IProductStatusService productStatusService)
        {
            _productStatusService = productStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productStatusService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductStatus(int id)
        {
            var productStatus = await _productStatusService.GetProductStatus(id);
            if (productStatus == null)
            {
                return NotFound();
            }
            return Ok(productStatus);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductStatus(string ProductStatusName)
        {
            var productStatus = await _productStatusService.AddProductStatus(ProductStatusName);
            return CreatedAtAction(nameof(GetProductStatus), new { id = productStatus.ProductStatusId }, productStatus);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductStatus(int ProductStatusId, string? ProductStatusName)
        {
            var productStatus = await _productStatusService.UpdateProductStatus(ProductStatusId, ProductStatusName);
            return Ok(productStatus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductStatus(int id)
        {
            var productStatus = await _productStatusService.DeleteProductStatus(id);
            if (productStatus == null)
            {
                return NotFound();
            }
            return Ok(productStatus);
        }


    }
}
