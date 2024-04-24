using factoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawMaterialController : ControllerBase
    {

        private readonly IRawMaterialService _rawMaterialService;

        public RawMaterialController(IRawMaterialService rawMaterialService)
        {
            _rawMaterialService = rawMaterialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rawMaterialService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRawMaterial(int id)
        {
            var rawMaterial = await _rawMaterialService.GetRawMaterial(id);
            if (rawMaterial == null)
            {
                return NotFound();
            }
            return Ok(rawMaterial);
        }

        [HttpPost]
        public async Task<IActionResult> AddRawMaterial(
            string RawMaterialName,
            string RawMaterialDescription,
            int RawMaterialProviderId)
        {
            var rawMaterial = await _rawMaterialService.AddRawMaterial(
                RawMaterialName,
                RawMaterialDescription,
                RawMaterialProviderId);
            return CreatedAtAction(nameof(GetRawMaterial), new { id = rawMaterial.RawMaterialId }, rawMaterial);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRawMaterial(
            int RawMaterialId,
            string? RawMaterialName,
            string? RawMaterialDescription,
            int? RawMaterialProviderId)
        {
            var rawMaterial = await _rawMaterialService.UpdateRawMaterial(
                RawMaterialId,
                RawMaterialName,
                RawMaterialDescription,
                RawMaterialProviderId);
            return Ok(rawMaterial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRawMaterial(int id)
        {
            var rawMaterial = await _rawMaterialService.DeleteRawMaterial(id);
            if (rawMaterial == null)
            {
                return NotFound();
            }
            return Ok(rawMaterial);
        }
    }
}
