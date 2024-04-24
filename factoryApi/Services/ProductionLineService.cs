using factoryApi.Model;
using factoryApi.Repositories;

namespace factoryApi.Services
{

    public interface IProductionLineService
    {
        Task<List<ProductionLine>> GetAll();
        Task<ProductionLine?> GetProductionLine(int id);

        Task<ProductionLine> AddProductionLine(
            string ProductionLineName,
            string ProductionLineDescription,
            int ProductionCapacityId);

        Task<ProductionLine> UpdateProductionLine(
            int ProductionLineId,
            string? ProductionLineName,
            string? ProductionLineDescription,
            int? ProductionCapacityId);

        Task<ProductionLine?> DeleteProductionLine(int id);
    }

    public class ProductionLineService : IProductionLineService
    {
        private readonly IProductionLineRepository _productionLineRepository;

        public ProductionLineService(IProductionLineRepository productionLineRepository)
        {
            _productionLineRepository = productionLineRepository;
        }

        public async Task<List<ProductionLine>> GetAll()
        {
            return await _productionLineRepository.GetAll();
        }

        public async Task<ProductionLine?> GetProductionLine(int id)
        {
            return await _productionLineRepository.GetProductionLine(id);
        }

        public async Task<ProductionLine> AddProductionLine(
            string ProductionLineName,
            string ProductionLineDescription,
            int ProductionCapacityId)
        {
            return await _productionLineRepository.AddProductionLine(
                ProductionLineName,
                ProductionLineDescription,
                ProductionCapacityId);
        }

        public async Task<ProductionLine> UpdateProductionLine(
            int ProductionLineId,
            string? ProductionLineName,
            string? ProductionLineDescription,
            int? ProductionCapacityId)
        {
            ProductionLine? productionLine = await _productionLineRepository.GetProductionLine(ProductionLineId);
            if (productionLine == null)
            {
                throw new Exception("Production Line not found");
            }
            if (ProductionLineName != null)
            {
                productionLine.ProductionLineName = ProductionLineName;
            }

            if (ProductionLineDescription != null)
            {
                productionLine.ProductionLineDescription = ProductionLineDescription;
            }

            if (ProductionCapacityId != null)
            {
                productionLine.ProductionCapacityId = ProductionCapacityId.Value;
            }

            return await _productionLineRepository.UpdateProductionLine(productionLine);
        }

        public async Task<ProductionLine?> DeleteProductionLine(int id)
        {
            return await _productionLineRepository.DeleteProductionLine(id);
        }
    }
}
