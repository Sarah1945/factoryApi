using factoryApi.Model;
using factoryApi.Repositories;

namespace factoryApi.Services
{

    public interface IProductionCapacityService
    {
        Task<List<ProductionCapacity>> GetAll();
        Task<ProductionCapacity?> GetProductionCapacity(int id);

        Task<ProductionCapacity> AddProductionCapacity(
            string ProductionCapacityName,
            int ProductionCapacityAmount
        );

        Task<ProductionCapacity> UpdateProductionCapacity(
            int ProductionCapacityId,
            string? ProductionCapacityName,
            int? ProductionCapacityAmount
        );

        Task<ProductionCapacity?> DeleteProductionCapacity(int id);


        public class ProductionCapacityService : IProductionCapacityService
        {
            private readonly IProductionCapacityRepository _productionCapacityRepository;

            public ProductionCapacityService(IProductionCapacityRepository productionCapacityRepository)
            {
                _productionCapacityRepository = productionCapacityRepository;
            }

            public async Task<List<ProductionCapacity>> GetAll()
            {
                return await _productionCapacityRepository.GetAll();
            }

            public async Task<ProductionCapacity?> GetProductionCapacity(int id)
            {
                return await _productionCapacityRepository.GetProductionCapacity(id);
            }

            public async Task<ProductionCapacity> AddProductionCapacity(
                string ProductionCapacityName,
                int ProductionCapacityAmount
            )
            {
                return await _productionCapacityRepository.AddProductionCapacity(ProductionCapacityName,
                    ProductionCapacityAmount);
            }

            public async Task<ProductionCapacity> UpdateProductionCapacity(
                int ProductionCapacityId,
                string? ProductionCapacityName,
                int? ProductionCapacityAmount
            )
            {
                ProductionCapacity? productionCapacity =
                    await _productionCapacityRepository.GetProductionCapacity(ProductionCapacityId);
                if (productionCapacity == null)
                {
                    throw new Exception("ProductionCapacity not found");
                }

                if (ProductionCapacityName != null)
                {
                    productionCapacity.ProductionCapacityName = ProductionCapacityName;
                }

                if (ProductionCapacityAmount != null)
                {
                    productionCapacity.ProductionCapacityAmount = ProductionCapacityAmount.Value;
                }

                return await _productionCapacityRepository.UpdateProductionCapacity(productionCapacity);
            }

            public async Task<ProductionCapacity?> DeleteProductionCapacity(int id)
            {
                return await _productionCapacityRepository.DeleteProductionCapacity(id);
            }
        }
    }
}
