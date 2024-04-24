namespace factoryApi.Model
{
    public class ProductionLine
    {
        public int ProductionLineId { get; set; }
        public required string ProductionLineName { get; set; }
        public required string ProductionLineDescription { get; set; }
        public required int ProductionCapacityId { get; set; }
        public required bool IsDeleted { get; set; } = false;
        public virtual ProductionCapacity ProductionCapacity { get; set; }
    }
}
