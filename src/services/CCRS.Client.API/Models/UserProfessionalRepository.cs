using Azure.Core;
using CCRS.Core.Data;
using CCRS.Core.Messages;
using CCRS.User.API.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCRS.User.API.Models
{
    public class UserProfessionalRepository : IUserProfessionalRepository
    {
        private readonly UserProfessionalContext _context;

        public UserProfessionalRepository(UserProfessionalContext context )
        {
            _context = context;
        }

        public IUnifOfWork UnifOfWork => _context;

        public void Add(UserProfessional userProfessional)
        {
            _context.UserProfessional.Add(userProfessional);
        }

        public async Task<IEnumerable<UserProfessional>> GetAll()
        {
            return await _context.UserProfessional.AsNoTracking().ToListAsync();
        }

        public Task<UserProfessional> GetByCpfAsync(string cpf)
        {
            return _context.UserProfessional.FirstOrDefaultAsync(c => c.Cpf.Number == cpf);
        }

        public Task<UserProfessional> GetByEmail(string email)
        {
            return _context.UserProfessional.FirstOrDefaultAsync(c => c.Email.Address == email);
        }

        public Task<UserProfessional> GetByIdAsync(Guid id)
        {
            return _context.UserProfessional.FirstOrDefaultAsync(c => c.Id == id);
        }

        
        
        public async Task<UserProfessionalDetailsViewModel> Update(UserProfessionalDetailsViewModel userProfessionalViewModel)
        {
            var userProfessionalResult = await GetByIdAsync(userProfessionalViewModel.Id);

            if (userProfessionalResult == null){ throw new InvalidOperationException("User Professional not found."); };
            

            if (!string.IsNullOrEmpty(userProfessionalViewModel.NutritionistCouncilNumber))
            {
                userProfessionalResult.SetNutritionistCouncilNumber(userProfessionalViewModel.NutritionistCouncilNumber);
            }

            if(!string.IsNullOrEmpty(userProfessionalViewModel.CountryOfCertification))
            {
                userProfessionalResult.SetCountryOfCertification(userProfessionalViewModel.CountryOfCertification);
            }

            if (!string.IsNullOrEmpty(userProfessionalViewModel.Nacionality))
            {
                userProfessionalResult.SetNacionality(userProfessionalViewModel.Nacionality);
            }

            _context.UserProfessional.Update(userProfessionalResult);

            await _context.SaveChangesAsync();

            return userProfessionalViewModel;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }       
    }
}
