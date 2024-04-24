namespace factoryApi.Model
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public required string ProviderName { get; set; }
        public required string ProviderCompany{ get; set; }
        public required int ProviderPhone { get; set; }
        public required bool IsDeleted { get; set; } = false;

    }
}
