using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IRawMaterialProductRepository
    {
        Task<List<RawMaterialProduct>> GetAll();
        Task<RawMaterialProduct?> GetRawMaterialProduct(int id);
        Task<RawMaterialProduct> AddRawMaterialProduct(
            int RawMaterialId,
            int ProductId,
            int RawMaterialProductStock
            );
        Task<RawMaterialProduct> UpdateRawMaterialProduct(RawMaterialProduct rawMaterialProduct);
        Task<RawMaterialProduct?> DeleteRawMaterialProduct(int id);

        public class RawMaterialProductRepository : IRawMaterialProductRepository
        {
            private readonly FactoryDbContext _context;

            public RawMaterialProductRepository(FactoryDbContext context)
            {
                _context = context;
            }

            public async Task<List<RawMaterialProduct>> GetAll()
            {
                return await _context.RawMaterialProducts.ToListAsync();
            }

            public async Task<RawMaterialProduct?> GetRawMaterialProduct(int id)
            {
                return await _context.RawMaterialProducts.FindAsync(id);
            }

            public async Task<RawMaterialProduct> AddRawMaterialProduct(
                int RawMaterialId,
                int ProductId,
                int RawMaterialProductStock
            )
            {
                RawMaterialProduct rawMaterialProduct = new RawMaterialProduct
                {
                    RawMaterialId = RawMaterialId,
                    ProductId = ProductId,
                    RawMaterialProductStock = RawMaterialProductStock,
                    IsDeleted = false
                };
                _context.RawMaterialProducts.Add(rawMaterialProduct);
                await _context.SaveChangesAsync();
                return rawMaterialProduct;
            }

            public async Task<RawMaterialProduct> UpdateRawMaterialProduct(RawMaterialProduct rawMaterialProduct)
            {
                _context.RawMaterialProducts.Update(rawMaterialProduct);
                await _context.SaveChangesAsync();
                return rawMaterialProduct;
            }

            public async Task<RawMaterialProduct?> DeleteRawMaterialProduct(int id)
            {
                RawMaterialProduct? rawMaterialProduct = await _context.RawMaterialProducts.FindAsync(id);
                if (rawMaterialProduct != null)
                {
                    rawMaterialProduct.IsDeleted = true;
                    _context.RawMaterialProducts.Update(rawMaterialProduct);
                    await _context.SaveChangesAsync();
                }
                return rawMaterialProduct;
            }
        }
    }
}