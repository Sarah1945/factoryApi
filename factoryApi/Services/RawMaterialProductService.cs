using factoryApi.Context;
using factoryApi.Model;
using factoryApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Services
{

    public interface IRawMaterialProductService
    {
        Task<List<RawMaterialProduct>> GetAll();
        Task<RawMaterialProduct?> GetRawMaterialProduct(int id);
        Task<RawMaterialProduct> AddRawMaterialProduct(
            int RawMaterialId,
            int ProductId,
            int RawMaterialProductStock
            );
        Task<RawMaterialProduct> UpdateRawMaterialProduct(
            int RawMaterialProductId,
            int? RawMaterialId,
            int? ProductId,
            int? RawMaterialProductStock
        );
        Task<RawMaterialProduct?> DeleteRawMaterialProduct(int id);
    }

    public class RawMaterialProductService : IRawMaterialProductService
    {
        private readonly IRawMaterialProductRepository _rawMaterialProductRepository;

        public RawMaterialProductService(IRawMaterialProductRepository rawMaterialProductRepository)
        {
            _rawMaterialProductRepository = rawMaterialProductRepository;
        }

        public async Task<List<RawMaterialProduct>> GetAll()
        {
            return await _rawMaterialProductRepository.GetAll();
        }

        public async Task<RawMaterialProduct?> GetRawMaterialProduct(int id)
        {
            return await _rawMaterialProductRepository.GetRawMaterialProduct(id);
        }

        public async Task<RawMaterialProduct> AddRawMaterialProduct(
            int RawMaterialId,
            int ProductId,
            int RawMaterialProductStock
        )
        {
            return await _rawMaterialProductRepository.AddRawMaterialProduct(
                  RawMaterialId,
                  ProductId,
                  RawMaterialProductStock);
        }

        public async Task<RawMaterialProduct> UpdateRawMaterialProduct(
            int RawMaterialProductId,
            int? RawMaterialId,
            int? ProductId,
            int? RawMaterialProductStock
        )
        {
            RawMaterialProduct? rawMaterialProduct = await _rawMaterialProductRepository.GetRawMaterialProduct(RawMaterialProductId);
            if (rawMaterialProduct == null)
            {
                throw new Exception("RawMaterialProduct not found");
            }

            if (RawMaterialId != null)
            {
                rawMaterialProduct.RawMaterialId = (int)RawMaterialId;
            }

            if (RawMaterialProductStock != null)
            {
                rawMaterialProduct.RawMaterialProductStock = (int)RawMaterialProductStock;
            }

            if (ProductId != null)
            {
                rawMaterialProduct.ProductId = (int)ProductId;
            }

            return await _rawMaterialProductRepository.UpdateRawMaterialProduct(rawMaterialProduct);
        }

        public async Task<RawMaterialProduct?> DeleteRawMaterialProduct(int id)
        {
            return await _rawMaterialProductRepository.DeleteRawMaterialProduct(id);
        }
    }
}


