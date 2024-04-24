using factoryApi.Model;
using factoryApi.Repositories;

namespace factoryApi.Services
{

    public interface IRawMaterialService
    {
        public Task<List<RawMaterial>> GetAll();
        public Task<RawMaterial?> GetRawMaterial(int id);
        public Task<RawMaterial> AddRawMaterial(
            string RawMaterialName,
            string RawMaterialDescription,
            int ProviderId);
        public Task<RawMaterial> UpdateRawMaterial(
            int RawMaterialId,
            string? RawMaterialName,
            string? RawMaterialDescription,
            int? ProviderId);
        public Task<RawMaterial?> DeleteRawMaterial(int id);

    }

    public class RawMaterialService : IRawMaterialService
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;

        public RawMaterialService(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task<List<RawMaterial>> GetAll()
        {
            return await _rawMaterialRepository.GetAll();
        }

        public async Task<RawMaterial?> GetRawMaterial(int id)
        {
            return await _rawMaterialRepository.GetRawMaterial(id);
        }

        public async Task<RawMaterial> AddRawMaterial(
            string RawMaterialName,
            string RawMaterialDescription,
            int ProviderId)
        {
            return await _rawMaterialRepository.AddRawMaterial(
                RawMaterialName,
                RawMaterialDescription,
                ProviderId);
        }

        public async Task<RawMaterial> UpdateRawMaterial(
            int RawMaterialId,
            string? RawMaterialName,
            string? RawMaterialDescription,
            int? ProviderId)
        {
            RawMaterial? rawMaterial = await _rawMaterialRepository.GetRawMaterial(RawMaterialId);
            if (rawMaterial == null)
            {
                throw new Exception("RawMaterial not found");
            }

            if (RawMaterialName != null)
            {
                rawMaterial.RawMaterialName = RawMaterialName;
            }

            if (RawMaterialDescription != null)
            {
                rawMaterial.RawMaterialDescription = RawMaterialDescription;
            }

            if (ProviderId != null)
            {
                rawMaterial.ProviderId = ProviderId.Value;
            }

            return await _rawMaterialRepository.UpdateRawMaterial(rawMaterial);
        }

        public async Task<RawMaterial?> DeleteRawMaterial(int id)
        {
            return await _rawMaterialRepository.DeleteRawMaterial(id);
        }
    }
}

