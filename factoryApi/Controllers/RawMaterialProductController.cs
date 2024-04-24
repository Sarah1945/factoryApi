using factoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialProductController : ControllerBase
    {

        private readonly IRawMaterialProductService _rawMaterialProductService;

        public RawMaterialProductController(IRawMaterialProductService rawMaterialProductService)
        {
            _rawMaterialProductService = rawMaterialProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rawMaterialProductService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRawMaterialProduct(int id)
        {
            var rawMaterialProduct = await _rawMaterialProductService.GetRawMaterialProduct(id);
            if (rawMaterialProduct == null)
            {
                return NotFound();
            }
            return Ok(rawMaterialProduct);
        }

        [HttpPost]
        public async Task<IActionResult> AddRawMaterialProduct(
            int RawMaterialId,
            int Product,
            int RawMaterialProductStock)
        {
            var rawMaterialProduct = await _rawMaterialProductService.AddRawMaterialProduct(
                RawMaterialId,
                Product,
                RawMaterialProductStock);
            return CreatedAtAction(nameof(GetRawMaterialProduct), new { id = rawMaterialProduct.RawMaterialProductId }, rawMaterialProduct);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRawMaterialProduct(
            int RawMaterialProductId,
            int? RawMaterialId,
            int? Product,
            int? RawMaterialProductStock)
        {
            var rawMaterialProduct = await _rawMaterialProductService.UpdateRawMaterialProduct(
                RawMaterialProductId,
                RawMaterialId,
                Product,
                RawMaterialProductStock);
            return Ok(rawMaterialProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRawMaterialProduct(int id)
        {
            var rawMaterialProduct = await _rawMaterialProductService.DeleteRawMaterialProduct(id);
            if (rawMaterialProduct == null)
            {
                return NotFound();
            }
            return Ok(rawMaterialProduct);
        }

    }
}
