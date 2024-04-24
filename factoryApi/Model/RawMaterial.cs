namespace factoryApi.Model
{
    public class RawMaterial
    {
        public int RawMaterialId { get; set; }
        public required string RawMaterialName { get; set; }
        public required string RawMaterialDescription { get; set; }
        public int ProviderId { get; set; }
        public required bool IsDeleted { get; set; } = false;
        public virtual Provider Provider { get; set; }
    }
}
