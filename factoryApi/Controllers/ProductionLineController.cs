using factoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionLineController : ControllerBase
    {

        private readonly IProductionLineService _productionLineService;

        public ProductionLineController(IProductionLineService productionLineService)
        {
            _productionLineService = productionLineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productionLineService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductionLine(int id)
        {
            var productionLine = await _productionLineService.GetProductionLine(id);
            if (productionLine == null)
            {
                return NotFound();
            }
            return Ok(productionLine);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductionLine(
            string ProductionLineName,
            string ProductionLineDescription,
            int ProductionCapacityId)
        {
            var productionLine = await _productionLineService.AddProductionLine(
                ProductionLineName,
                ProductionLineDescription,
                ProductionCapacityId);
            return CreatedAtAction(nameof(GetProductionLine), new { id = productionLine.ProductionLineId }, productionLine);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductionLine(
            int ProductionLineId,
            string? ProductionLineName,
            string? ProductionLineDescription,
            int? ProductionCapacityId)
        {
            var productionLine = await _productionLineService.UpdateProductionLine(
                ProductionLineId,
                ProductionLineName,
                ProductionLineDescription,
                ProductionCapacityId);
            return Ok(productionLine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionLine(int id)
        {
            var productionLine = await _productionLineService.DeleteProductionLine(id);
            if (productionLine == null)
            {
                return NotFound();
            }
            return Ok(productionLine);
        }

    }
}
