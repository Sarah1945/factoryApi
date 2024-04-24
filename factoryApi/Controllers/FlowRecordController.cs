using factoryApi.Model;
using factoryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace factoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowRecordController : ControllerBase
    {

        private readonly IFlowRecordService _flowRecordService;

        public FlowRecordController(IFlowRecordService flowRecordService)
        {
            _flowRecordService = flowRecordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _flowRecordService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlowRecord(int id)
        {
            var flowRecord = await _flowRecordService.GetFlowRecord(id);
            if (flowRecord == null)
            {
                return NotFound();
            }
            return Ok(flowRecord);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlowRecord(
            string FlowRecordName,
            DateTime FlowRecordDate,
            int ProductId,
            int RegistrationActionId)
        {
            var flowRecord = await _flowRecordService.AddFlowRecord(
                FlowRecordName,
                FlowRecordDate,
                ProductId,
                RegistrationActionId);
            return CreatedAtAction(nameof(GetFlowRecord), new { id = flowRecord.FlowRecordId }, flowRecord);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFlowRecord(
            int FlowRecordId,
            string? FlowRecordName,
            DateTime? FlowRecordDate,
            int? ProductId,
            int? RegistrationActionId)
        {
            var flowRecord = await _flowRecordService.UpdateFlowRecord(
                FlowRecordId,
                FlowRecordName,
                FlowRecordDate,
                ProductId,
                RegistrationActionId);

            return Ok(flowRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlowRecord(int id)
        {
            var flowRecord = await _flowRecordService.DeleteFlowRecord(id);
            if (flowRecord == null)
            {
                return NotFound();
            }
            return Ok(flowRecord);
        }


    }
}
