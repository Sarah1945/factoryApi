using factoryApi.Model;
using factoryApi.Repositories;

namespace factoryApi.Services
{

    public interface IProviderService
    {
        Task<List<Provider>> GetAll();
        Task<Provider?> GetProvider(int id);
        Task<Provider> AddProvider(
            string ProviderName,
            string ProviderCompany,
            int ProviderPhone);
        Task<Provider> UpdateProvider(
            int ProviderId,
            string? ProviderName,
            string? ProviderCompany,
            int? ProviderPhone);
        Task<Provider?> DeleteProvider(int id);
    }

    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<List<Provider>> GetAll()
        {
            return await _providerRepository.GetAll();
        }

        public async Task<Provider?> GetProvider(int id)
        {
            return await _providerRepository.GetProvider(id);
        }

        public async Task<Provider> AddProvider(
            string ProviderName,
            string ProviderCompany,
            int ProviderPhone)
        {
            return await _providerRepository.AddProvider(ProviderName, ProviderCompany, ProviderPhone);
        }

        public async Task<Provider> UpdateProvider(
            int ProviderId,
            string? ProviderName,
            string? ProviderCompany,
            int? ProviderPhone)
        {
            Provider? provider = await _providerRepository.GetProvider(ProviderId);
            if (provider == null)
            {
                throw new Exception("Provider not found");
            }

            if (ProviderName != null)
            {
                provider.ProviderName = ProviderName;
            }

            if (ProviderCompany != null)
            {
                provider.ProviderCompany = ProviderCompany;
            }

            if (ProviderPhone != null)
            {
                provider.ProviderPhone = ProviderPhone.Value;
            }

            return await _providerRepository.UpdateProvider(provider);
        }

        public async Task<Provider?> DeleteProvider(int id)
        {
            return await _providerRepository.DeleteProvider(id);
        }
    }
}
