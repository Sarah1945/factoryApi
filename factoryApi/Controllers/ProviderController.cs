using factoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {

        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _providerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvider(int id)
        {
            var provider = await _providerService.GetProvider(id);
            if (provider == null)
            {
                return NotFound();
            }
            return Ok(provider);
        }

        [HttpPost]
        public async Task<IActionResult> AddProvider(
            string ProviderName,
            string ProviderCompany,
            int ProviderPhone)
        {
            var provider = await _providerService.AddProvider(
                ProviderName,
                ProviderCompany,
                ProviderPhone);
            return CreatedAtAction(nameof(GetProvider), new { id = provider.ProviderId }, provider);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProvider(
            int ProviderId,
            string? ProviderName,
            string? ProviderCompany,
            int? ProviderPhone)
        {
            var provider = await _providerService.UpdateProvider(
                ProviderId,
                ProviderName,
                ProviderCompany,
                ProviderPhone);
            return Ok(provider);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            var provider = await _providerService.DeleteProvider(id);
            if (provider == null)
            {
                return NotFound();
            }
            return Ok(provider);
        }


    }
}
