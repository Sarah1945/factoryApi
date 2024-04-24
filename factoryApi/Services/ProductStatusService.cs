using factoryApi.Model;
using factoryApi.Repositories;

namespace factoryApi.Services
{

    public interface IProductStatusService
    {
        Task<List<ProductStatus>> GetAll();
        Task<ProductStatus?> GetProductStatus(int id);
        Task<ProductStatus> AddProductStatus(
            string ProductStatusName);
        Task<ProductStatus> UpdateProductStatus(
            int ProductStatusId,
            string? ProductStatusName);
        Task<ProductStatus?> DeleteProductStatus(int id);
    }

    public class ProductStatusService : IProductStatusService
    {
        private readonly IProductStatusRepository _productStatusRepository;

        public ProductStatusService(IProductStatusRepository productStatusRepository)
        {
            _productStatusRepository = productStatusRepository;
        }

        public async Task<List<ProductStatus>> GetAll()
        {
            return await _productStatusRepository.GetAll();
        }

        public async Task<ProductStatus?> GetProductStatus(int id)
        {
            return await _productStatusRepository.GetProductStatus(id);
        }

        public async Task<ProductStatus> AddProductStatus(
            string ProductStatusName)
        {
            return await _productStatusRepository.AddProductStatus(ProductStatusName);
        }

        public async Task<ProductStatus> UpdateProductStatus(
            int ProductStatusId,
            string? ProductStatusName)
        {
            ProductStatus? productStatus = await _productStatusRepository.GetProductStatus(ProductStatusId);
            if (productStatus == null)
            {
                throw new System.Exception("ProductStatus not found");
            }

            if (ProductStatusName != null)
            {
                productStatus.ProductStatusName = ProductStatusName;
            }

            return await _productStatusRepository.UpdateProductStatus(productStatus);
        }

        public async Task<ProductStatus?> DeleteProductStatus(int id)
        {
            return await _productStatusRepository.DeleteProductStatus(id);
        }
    }
}
