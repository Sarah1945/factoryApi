namespace factoryApi.Model
{
    public class RawMaterialProduct
    {
        public int RawMaterialProductId { get; set; }
        public required int RawMaterialId { get; set; }

        public required int ProductId { get; set; }
        public required int RawMaterialProductStock { get; set; }
        public required bool IsDeleted { get; set; } = false;

        public virtual RawMaterial RawMaterial { get; set; }
        public virtual Product Product { get; set; }
    }
}
