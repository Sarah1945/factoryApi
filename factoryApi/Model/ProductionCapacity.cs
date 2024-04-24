namespace factoryApi.Model
{
    public class ProductionCapacity
    {
        public int ProductionCapacityId { get; set; }
        public required string ProductionCapacityName { get; set; }
        public required bool IsDeleted { get; set; } = false;

        public required int ProductionCapacityAmount { get; set; }
    }
}
