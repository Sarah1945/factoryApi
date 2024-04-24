using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IProductionLineRepository
    {
        Task<List<ProductionLine>> GetAll();
        Task<ProductionLine?> GetProductionLine(int id);
        Task<ProductionLine> AddProductionLine(
            string ProductionLineName,
            string ProductionLineDescription,
            int ProductionCapacityId);
        Task<ProductionLine> UpdateProductionLine(ProductionLine productionLine);
        Task<ProductionLine?> DeleteProductionLine(int id);

        public class ProductionLineRepository : IProductionLineRepository
        {
            private readonly FactoryDbContext _context;

            public ProductionLineRepository(FactoryDbContext context)
            {
                _context = context;
            }

            public async Task<List<ProductionLine>> GetAll()
            {
                return await _context.ProductionLines.ToListAsync();
            }

            public async Task<ProductionLine?> GetProductionLine(int id)
            {
                return await _context.ProductionLines.FindAsync(id);
            }

            public async Task<ProductionLine> AddProductionLine(
                           string ProductionLineName,
                           string ProductionLineDescription,
                           int ProductionCapacityId)
            {
                ProductionLine productionLine = new ProductionLine
                {
                    ProductionLineName = ProductionLineName,
                    ProductionLineDescription = ProductionLineDescription,
                    ProductionCapacityId = ProductionCapacityId,
                    IsDeleted = false
                };
                _context.ProductionLines.Add(productionLine);
                await _context.SaveChangesAsync();
                return productionLine;
            }

            public async Task<ProductionLine> UpdateProductionLine(ProductionLine productionLine)
            {
                _context.ProductionLines.Update(productionLine);
                await _context.SaveChangesAsync();
                return productionLine;
            }

            public async Task<ProductionLine?> DeleteProductionLine(int id)
            {
                ProductionLine? productionLine = await _context.ProductionLines.FindAsync(id);
                if (productionLine != null)
                {
                    productionLine.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
                return productionLine;
            }
        }
    }
}
