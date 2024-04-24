using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IProductStatusRepository
    {
        Task<List<ProductStatus>> GetAll();
        Task<ProductStatus?> GetProductStatus(int id);
        Task<ProductStatus> AddProductStatus(
            string ProductStatusName
            );
        Task<ProductStatus> UpdateProductStatus(ProductStatus productStatus);
        Task<ProductStatus?> DeleteProductStatus(int id);

        public class ProductStatusRepository : IProductStatusRepository
        {
            private readonly FactoryDbContext _context;

            public ProductStatusRepository(FactoryDbContext context)
            {
                _context = context;
            }

            public async Task<List<ProductStatus>> GetAll()
            {
                return await _context.ProductStatuses.ToListAsync();
            }

            public async Task<ProductStatus?> GetProductStatus(int id)
            {
                return await _context.ProductStatuses.FindAsync(id);
            }

            public async Task<ProductStatus> AddProductStatus(
                string ProductStatusName
            )
            {
                ProductStatus productStatus = new ProductStatus
                {
                    ProductStatusName = ProductStatusName,
                    IsDeleted = false
                };
                _context.ProductStatuses.Add(productStatus);
                await _context.SaveChangesAsync();
                return productStatus;
            }

            public async Task<ProductStatus> UpdateProductStatus(ProductStatus productStatus)
            {
                _context.ProductStatuses.Update(productStatus);
                await _context.SaveChangesAsync();
                return productStatus;
            }

            public async Task<ProductStatus?> DeleteProductStatus(int id)
            {
                ProductStatus? productStatus = await _context.ProductStatuses.FindAsync(id);
                if (productStatus == null)
                {
                    return null;
                }
                productStatus.IsDeleted = true;
                _context.ProductStatuses.Update(productStatus);
                await _context.SaveChangesAsync();
                return productStatus;
            }
        }
    }
}
