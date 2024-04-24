namespace factoryApi.Model
{
    public class Product
    {

        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public required int ProductStatusId { get; set; }
        public required int ProductionLineId { get; set; }
        public required bool IsDeleted { get; set; } = false;

        public virtual ProductStatus ProductStatus { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }



    }
}
