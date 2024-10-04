using Azure.Core;
using CCRS.Core.Data;
using CCRS.Core.Messages;
using CCRS.User.API.Models.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CCRS.User.API.Models
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly UserProfileContext _context;

        public UserProfileRepository(UserProfileContext context )
        {
            _context = context;
        }

        public IUnifOfWork UnifOfWork => _context;

        public void Add(UserProfile userProfile)
        {
            _context.UserProfile.Add(userProfile);
        }

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await _context.UserProfile.AsNoTracking().ToListAsync();
        }

        public Task<UserProfile> GetByCpfAsync(string cpf)
        {
            return _context.UserProfile.FirstOrDefaultAsync(c => c.Cpf.Number == cpf);
        }

        public Task<UserProfile> GetByEmail(string email)
        {
            return _context.UserProfile.FirstOrDefaultAsync(c => c.Email.Address == email);
        }

        public Task<UserProfile> GetByIdAsync(Guid id)
        {
            return _context.UserProfile.FirstOrDefaultAsync(c => c.Id == id);
        }

        
        
        public async Task<UserProfileDetailsViewModel> Update(UserProfileDetailsViewModel userProfileViewModel)
        {
            var userProfileResult = await GetByIdAsync(userProfileViewModel.Id);

            if (userProfileResult == null){ throw new InvalidOperationException("User profile not found."); };
            

            if (!string.IsNullOrEmpty(userProfileViewModel.NutritionistCouncilNumber))
            {
                userProfileResult.SetNutritionistCouncilNumber(userProfileViewModel.NutritionistCouncilNumber);
            }

            if(!string.IsNullOrEmpty(userProfileViewModel.CountryOfCertification))
            {
                userProfileResult.SetCountryOfCertification(userProfileViewModel.CountryOfCertification);
            }

            if (!string.IsNullOrEmpty(userProfileViewModel.Nacionality))
            {
                userProfileResult.SetNacionality(userProfileViewModel.Nacionality);
            }

            _context.UserProfile.Update(userProfileResult);

            await _context.SaveChangesAsync();

            return userProfileViewModel;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }       
    }
}
