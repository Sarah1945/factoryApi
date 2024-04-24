using factoryApi.Model;
using factoryApi.Repositories;

namespace factoryApi.Services
{

    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetProduct(int id);

        Task<Product> AddProduct(
            string ProductName,
            string ProductDescription,
            int ProductStatusId,
            int ProductionLineId);

        Task<Product> UpdateProduct(
            int ProductId,
            string? ProductName,
            string? ProductDescription,
            int? ProductStatusId,
            int? ProductionLineId);

        Task<Product?> DeleteProduct(int id);
    }


    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _productRepository.GetProduct(id);
        }

        public async Task<Product> AddProduct(
            string ProductName,
            string ProductDescription,
            int ProductStatusId,
            int ProductionLineId
        )
        {
            return await _productRepository.AddProduct(ProductName, ProductDescription, ProductStatusId, ProductionLineId);
        }

        public async Task<Product> UpdateProduct(
            int ProductId,
            string? ProductName,
            string? ProductDescription,
            int? ProductStatusId,
            int? ProductionLineId
        )
        {
            Product? product = await _productRepository.GetProduct(ProductId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            if (ProductName != null)
            {
                product.ProductName = ProductName;
            }

            if (ProductDescription != null)
            {
                product.ProductDescription = ProductDescription;
            }

            if (ProductStatusId != null)
            {
                product.ProductStatusId = ProductStatusId.Value;
            }

            if (ProductionLineId != null)
            {
                product.ProductionLineId = ProductionLineId.Value;
            }
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}
