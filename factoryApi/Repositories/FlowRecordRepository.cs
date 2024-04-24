using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IFlowRecordRepository
    {
        Task<List<FlowRecord>> GetAll();
        Task<FlowRecord?> GetFlowRecord(int id);

        Task<FlowRecord> AddFlowRecord(
            string FlowRecordName,
            DateTime FlowRecordDate,
            int ProductId,
            int RegistrationActionId
        );

        Task<FlowRecord> UpdateFlowRecord(FlowRecord flowRecord);
        Task<FlowRecord?> DeleteFlowRecord(int id);

        public class FlowRecordRepository : IFlowRecordRepository
        {
            private readonly FactoryDbContext _context;

            public FlowRecordRepository(FactoryDbContext context)
            {
                _context = context;
            }

            public async Task<List<FlowRecord>> GetAll()
            {
                return await _context.FlowRecords.ToListAsync();
            }

            public async Task<FlowRecord?> GetFlowRecord(int id)
            {
                return await _context.FlowRecords.FindAsync(id);
            }

            public async Task<FlowRecord> AddFlowRecord(
                string FlowRecordName,
                DateTime FlowRecordDate,
                int ProductId,
                int RegistrationActionId
            )
            {
                FlowRecord flowRecord = new FlowRecord
                {
                    FlowRecordName = FlowRecordName,
                    FlowRecordDate = FlowRecordDate,
                    ProductId = ProductId,
                    RegistrationActionId = RegistrationActionId,
                    IsDeleted = false
                };
                _context.FlowRecords.Add(flowRecord);
                await _context.SaveChangesAsync();
                return flowRecord;
            }

            public async Task<FlowRecord> UpdateFlowRecord(FlowRecord flowRecord)
            {
                _context.Entry(flowRecord).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return flowRecord;
            }

            public async Task<FlowRecord?> DeleteFlowRecord(int id)
            {
                FlowRecord? flowRecord = await _context.FlowRecords.FindAsync(id);
                if (flowRecord == null)
                {
                    return null;
                }

                flowRecord.IsDeleted = true;
                _context.Entry(flowRecord).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return flowRecord;
            }
        }
    }
}
