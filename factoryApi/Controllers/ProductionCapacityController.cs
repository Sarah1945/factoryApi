using factoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionCapacityController : ControllerBase
    {

        private readonly IProductionCapacityService _productionCapacityService;

        public ProductionCapacityController(IProductionCapacityService productionCapacityService)
        {
            _productionCapacityService = productionCapacityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productionCapacityService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductionCapacity(int id)
        {
            var productionCapacity = await _productionCapacityService.GetProductionCapacity(id);
            if (productionCapacity == null)
            {
                return NotFound();
            }
            return Ok(productionCapacity);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductionCapacity(string ProductionCapacityName, int ProductionCapacityAmount)
        {
            var productionCapacity = await _productionCapacityService.AddProductionCapacity(ProductionCapacityName, ProductionCapacityAmount);
            return CreatedAtAction(nameof(GetProductionCapacity), new { id = productionCapacity.ProductionCapacityId }, productionCapacity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductionCapacity(int ProductionCapacityId,
            string? ProductionCapacityName, int? ProductionCapacityAmount)
        {
            var productionCapacity =
                await _productionCapacityService.UpdateProductionCapacity(
                    ProductionCapacityId,
                    ProductionCapacityName,
                    ProductionCapacityAmount);
            return Ok(productionCapacity);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionCapacity(int id)
        {
            var productionCapacity = await _productionCapacityService.DeleteProductionCapacity(id);
            if (productionCapacity == null)
            {
                return NotFound();
            }
            return Ok(productionCapacity);
        }

    }
}
