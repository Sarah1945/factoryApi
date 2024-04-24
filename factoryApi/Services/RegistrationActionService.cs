using factoryApi.Model;
using factoryApi.Repositories;

namespace factoryApi.Services
{

    public interface IRegistrationActionService
    {
        Task<List<RegistrationAction>> GetAll();
        Task<RegistrationAction?> GetRegistrationAction(int id);
        Task<RegistrationAction> AddRegistrationAction(string RegistrationActionName);
        Task<RegistrationAction> UpdateRegistrationAction(int RegistrationActionId, string? RegistrationActionName);
        Task<RegistrationAction?> DeleteRegistrationAction(int id);

        public class RegistrationActionService : IRegistrationActionService
        {
            private readonly IRegistrationActionRepository _registrationActionRepository;

            public RegistrationActionService(IRegistrationActionRepository registrationActionRepository)
            {
                _registrationActionRepository = registrationActionRepository;
            }

            public async Task<List<RegistrationAction>> GetAll()
            {
                return await _registrationActionRepository.GetAll();
            }

            public async Task<RegistrationAction?> GetRegistrationAction(int id)
            {
                return await _registrationActionRepository.GetRegistrationAction(id);
            }

            public async Task<RegistrationAction> AddRegistrationAction(string RegistrationActionName)
            {
                return await _registrationActionRepository.AddRegistrationAction(RegistrationActionName);
            }

            public async Task<RegistrationAction> UpdateRegistrationAction(int RegistrationActionId,
                string? RegistrationActionName)
            {
                RegistrationAction? registrationAction =
                    await _registrationActionRepository.GetRegistrationAction(RegistrationActionId);

                if (registrationAction == null)
                {
                    throw new Exception("RegistrationAction not found");
                }

                if (RegistrationActionName != null)
                {
                    registrationAction.RegistrationActionName = RegistrationActionName;
                }

                return await _registrationActionRepository.UpdateRegistrationAction(registrationAction);
            }

            public async Task<RegistrationAction?> DeleteRegistrationAction(int id)
            {
                return await _registrationActionRepository.DeleteRegistrationAction(id);
            }
        }
    }
}
