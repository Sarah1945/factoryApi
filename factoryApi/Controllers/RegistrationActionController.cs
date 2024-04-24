using factoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationActionController : ControllerBase
    {

        private readonly IRegistrationActionService _registrationActionService;

        public RegistrationActionController(IRegistrationActionService registrationActionService)
        {
            _registrationActionService = registrationActionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _registrationActionService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationAction(int id)
        {
            var registrationAction = await _registrationActionService.GetRegistrationAction(id);
            if (registrationAction == null)
            {
                return NotFound();
            }
            return Ok(registrationAction);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegistrationAction(string RegistrationActionName)
        {
            var registrationAction = await _registrationActionService.AddRegistrationAction(
                               RegistrationActionName);
            return CreatedAtAction(nameof(GetRegistrationAction), new { id = registrationAction.RegistrationActionId }, registrationAction);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegistrationAction(
            int RegistrationActionId,
            string? RegistrationActionName)
        {
            var registrationAction = await _registrationActionService.UpdateRegistrationAction(
                RegistrationActionId,
                RegistrationActionName);
            return Ok(registrationAction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationAction(int id)
        {
            var registrationAction = await _registrationActionService.DeleteRegistrationAction(id);
            if (registrationAction == null)
            {
                return NotFound();
            }
            return Ok(registrationAction);
        }
    }
}
