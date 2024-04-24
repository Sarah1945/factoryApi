using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IProviderRepository
    {
        Task<List<Provider>> GetAll();
        Task<Provider?> GetProvider(int id);
        Task<Provider> AddProvider(
            string ProviderName,
            string ProviderCompany,
            int ProviderPhone
            );
        Task<Provider> UpdateProvider(Provider provider);
        Task<Provider?> DeleteProvider(int id);
    }

    public class ProviderRepository : IProviderRepository
    {
        private readonly FactoryDbContext _context;

        public ProviderRepository(FactoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Provider>> GetAll()
        {
            return await _context.Providers.ToListAsync();
        }

        public async Task<Provider?> GetProvider(int id)
        {
            return await _context.Providers.FindAsync(id);
        }

        public async Task<Provider> AddProvider(
            string ProviderName,
            string ProviderCompany,
            int ProviderPhone
        )
        {
            Provider provider = new Provider
            {
                ProviderName = ProviderName,
                ProviderCompany = ProviderCompany,
                ProviderPhone = ProviderPhone,
                IsDeleted = false
            };
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider> UpdateProvider(Provider provider)
        {
            _context.Providers.Update(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<Provider?> DeleteProvider(int id)
        {
            Provider? provider = await _context.Providers.FindAsync(id);
            if (provider != null)
            {
                provider.IsDeleted = true;
                _context.Providers.Update(provider);
                await _context.SaveChangesAsync();
            }
            return provider;
        }
    }
}
