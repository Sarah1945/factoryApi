using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IRawMaterialRepository
    {
        Task<List<RawMaterial>> GetAll();
        Task<RawMaterial?> GetRawMaterial(int id);
        Task<RawMaterial> AddRawMaterial(
            string RawMaterialName,
            string RawMaterialDescription,
            int ProviderId
            );
        Task<RawMaterial> UpdateRawMaterial(RawMaterial rawMaterial);
        Task<RawMaterial?> DeleteRawMaterial(int id);
    }

    public class RawMaterialRepository : IRawMaterialRepository
    {
        private readonly FactoryDbContext _context;

        public RawMaterialRepository(FactoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<RawMaterial>> GetAll()
        {
            return await _context.RawMaterials.ToListAsync();
        }

        public async Task<RawMaterial?> GetRawMaterial(int id)
        {
            return await _context.RawMaterials.FindAsync(id);
        }

        public async Task<RawMaterial> AddRawMaterial(
            string RawMaterialName,
            string RawMaterialDescription,
            int ProviderId
        )
        {
            RawMaterial rawMaterial = new RawMaterial
            {
                RawMaterialName = RawMaterialName,
                RawMaterialDescription = RawMaterialDescription,
                ProviderId = ProviderId,
                IsDeleted = false
            };
            _context.RawMaterials.Add(rawMaterial);
            await _context.SaveChangesAsync();
            return rawMaterial;
        }

        public async Task<RawMaterial> UpdateRawMaterial(RawMaterial rawMaterial)
        {
            _context.RawMaterials.Update(rawMaterial);
            await _context.SaveChangesAsync();
            return rawMaterial;
        }

        public async Task<RawMaterial?> DeleteRawMaterial(int id)
        {
            RawMaterial? rawMaterial = await _context.RawMaterials.FindAsync(id);
            if (rawMaterial != null)
            {
                rawMaterial.IsDeleted = true;
                _context.RawMaterials.Update(rawMaterial);
                await _context.SaveChangesAsync();
            }
            return rawMaterial;
        }
    }
}
