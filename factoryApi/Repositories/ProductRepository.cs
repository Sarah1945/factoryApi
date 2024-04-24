using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetProduct(int id);
        Task<Product> AddProduct(
            string ProductName,
            string ProductDescription,
            int ProductStatusId,
            int ProductionLineId
            );
        Task<Product> UpdateProduct(Product product);
        Task<Product?> DeleteProduct(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly FactoryDbContext _context;

        public ProductRepository(FactoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddProduct(
            string ProductName,
            string ProductDescription,
            int ProductStatusId,
            int ProductionLineId
            )
        {
            Product product = new Product
            {
                ProductName = ProductName,
                ProductDescription = ProductDescription,
                ProductStatusId = ProductStatusId,
                ProductionLineId = ProductionLineId,
                IsDeleted = false
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            product.IsDeleted = true;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }


    }
}
