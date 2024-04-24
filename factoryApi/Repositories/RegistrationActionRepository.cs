using factoryApi.Context;
using factoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IRegistrationActionRepository
    {
        Task<List<RegistrationAction>> GetAll();
        Task<RegistrationAction?> GetRegistrationAction(int id);

        Task<RegistrationAction> AddRegistrationAction(
            string RegistrationActionName
        );

        Task<RegistrationAction> UpdateRegistrationAction(RegistrationAction registrationAction);
        Task<RegistrationAction?> DeleteRegistrationAction(int id);


        public class RegistrationActionRepository : IRegistrationActionRepository
        {
            private readonly FactoryDbContext _context;

            public RegistrationActionRepository(FactoryDbContext context)
            {
                _context = context;
            }

            public async Task<List<RegistrationAction>> GetAll()
            {
                return await _context.RegistrationActions.ToListAsync();
            }

            public async Task<RegistrationAction?> GetRegistrationAction(int id)
            {
                return await _context.RegistrationActions.FindAsync(id);
            }

            public async Task<RegistrationAction> AddRegistrationAction(
                string RegistrationActionName
            )
            {
                RegistrationAction registrationAction = new RegistrationAction
                {
                    RegistrationActionName = RegistrationActionName,
                    IsDeleted = false
                };
                _context.RegistrationActions.Add(registrationAction);
                await _context.SaveChangesAsync();
                return registrationAction;
            }

            public async Task<RegistrationAction> UpdateRegistrationAction(RegistrationAction registrationAction)
            {
                _context.RegistrationActions.Update(registrationAction);
                await _context.SaveChangesAsync();
                return registrationAction;
            }

            public async Task<RegistrationAction?> DeleteRegistrationAction(int id)
            {
                RegistrationAction? registrationAction = await _context.RegistrationActions.FindAsync(id);
                if (registrationAction != null)
                {
                    registrationAction.IsDeleted = true;
                    _context.RegistrationActions.Update(registrationAction);
                    await _context.SaveChangesAsync();
                }

                return registrationAction;
            }
        }
    }
}
