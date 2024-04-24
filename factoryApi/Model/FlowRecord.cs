namespace factoryApi.Model
{
    public class FlowRecord
    {
        public int FlowRecordId { get; set; }
        public required string FlowRecordName { get; set; }
        public required DateTime FlowRecordDate { get; set; }
        public required int ProductId { get; set; }
        public required int RegistrationActionId { get; set; }
        public required bool IsDeleted { get; set; } = false;

        public virtual Product? Product { get; set; }
        public virtual RegistrationAction? RegistrationAction { get; set; }

    }
}
