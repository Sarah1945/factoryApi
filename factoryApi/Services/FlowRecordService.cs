using factoryApi.Model;
using factoryApi.Repositories;

namespace factoryApi.Services
{

    public interface IFlowRecordService
    {
        Task<List<FlowRecord>> GetAll();
        Task<FlowRecord?> GetFlowRecord(int id);
        Task<FlowRecord> AddFlowRecord(
            string FlowRecordName,
            DateTime FlowRecordDate,
            int ProductId,
            int RegistrationActionId
            );
        Task<FlowRecord> UpdateFlowRecord(
            int FlowRecordId,
            string? FlowRecordName,
            DateTime? FlowRecordDate,
            int? ProductId,
            int? RegistrationActionId
            );
        Task<FlowRecord?> DeleteFlowRecord(int id);
    }

    public class FlowRecordService : IFlowRecordService
    {
        private readonly IFlowRecordRepository _flowRecordRepository;

        public FlowRecordService(IFlowRecordRepository flowRecordRepository)
        {
            _flowRecordRepository = flowRecordRepository;
        }

        public async Task<List<FlowRecord>> GetAll()
        {
            return await _flowRecordRepository.GetAll();
        }

        public async Task<FlowRecord?> GetFlowRecord(int id)
        {
            return await _flowRecordRepository.GetFlowRecord(id);
        }

        public async Task<FlowRecord> AddFlowRecord(
            string FlowRecordName,
            DateTime FlowRecordDate,
            int ProductId,
            int RegistrationActionId
        )
        {
            return await _flowRecordRepository.AddFlowRecord(
                FlowRecordName,
                FlowRecordDate,
                ProductId,
                RegistrationActionId
                );
        }

        public async Task<FlowRecord> UpdateFlowRecord(
            int FlowRecordId,
            string? FlowRecordName,
            DateTime? FlowRecordDate,
            int? ProductId,
            int? RegistrationActionId
        )
        {
            FlowRecord? flowRecord = await _flowRecordRepository.GetFlowRecord(FlowRecordId);
            if (flowRecord == null)
            {
                throw new Exception("FlowRecord not found");
            }

            if (FlowRecordName != null)
            {
                flowRecord.FlowRecordName = FlowRecordName;
            }

            if (FlowRecordDate != null)
            {
                flowRecord.FlowRecordDate = (DateTime)FlowRecordDate;
            }

            if (ProductId != null)
            {
                flowRecord.ProductId = (int)ProductId;
            }

            if (RegistrationActionId != null)
            {
                flowRecord.RegistrationActionId = (int)RegistrationActionId;
            }

            return await _flowRecordRepository.UpdateFlowRecord(flowRecord);
        }

        public async Task<FlowRecord?> DeleteFlowRecord(int id)
        {
            return await _flowRecordRepository.DeleteFlowRecord(id);
        }
    }
}
