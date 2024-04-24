namespace factoryApi.Model
{
    public class ProductStatus
    {
        public int ProductStatusId { get; set; }
        public required string ProductStatusName { get; set; }
        public required bool IsDeleted { get; set; } = false;
    }
}
