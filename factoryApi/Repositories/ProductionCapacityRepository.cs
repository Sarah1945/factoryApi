using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IProductionCapacityRepository
    {
        Task<List<ProductionCapacity>> GetAll();
        Task<ProductionCapacity?> GetProductionCapacity(int id);
        Task<ProductionCapacity> AddProductionCapacity(
            string ProductionCapacityName,
            int ProductionCapacityAmount
            );
        Task<ProductionCapacity> UpdateProductionCapacity(ProductionCapacity productionCapacity);
        Task<ProductionCapacity?> DeleteProductionCapacity(int id);
    }

    public class ProductionCapacityRepository : IProductionCapacityRepository
    {
        private readonly FactoryDbContext _context;

        public ProductionCapacityRepository(FactoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductionCapacity>> GetAll()
        {
            return await _context.ProductionCapacities.ToListAsync();
        }

        public async Task<ProductionCapacity?> GetProductionCapacity(int id)
        {
            return await _context.ProductionCapacities.FindAsync(id);
        }

        public async Task<ProductionCapacity> AddProductionCapacity(
            string ProductionCapacityName,
            int ProductionCapacityAmount
        )
        {
            ProductionCapacity productionCapacity = new ProductionCapacity
            {
                ProductionCapacityName = ProductionCapacityName,
                ProductionCapacityAmount = ProductionCapacityAmount,
                IsDeleted = false
            };
            _context.ProductionCapacities.Add(productionCapacity);
            await _context.SaveChangesAsync();
            return productionCapacity;
        }

        public async Task<ProductionCapacity> UpdateProductionCapacity(ProductionCapacity productionCapacity)
        {
            _context.ProductionCapacities.Update(productionCapacity);
            await _context.SaveChangesAsync();
            return productionCapacity;
        }

        public async Task<ProductionCapacity?> DeleteProductionCapacity(int id)
        {
            ProductionCapacity? productionCapacity = await _context.ProductionCapacities.FindAsync(id);
            if (productionCapacity != null)
            {
                productionCapacity.IsDeleted = true;
                _context.ProductionCapacities.Update(productionCapacity);
                await _context.SaveChangesAsync();
            }
            return productionCapacity;
        }
    }
}
