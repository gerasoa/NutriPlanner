using CCRS.Core.Data;
using CCRS.User.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CCRS.User.API.Models.Models
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly UserProfileContext _context;

        public UserProfileRepository(UserProfileContext context )
        {
            _context = context;
        }

        public IUnifOfWork UnifOfWork => _context;

        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await _context.UserProfile.AsNoTracking().ToListAsync();
        }

        public Task<UserProfile> GetByCpf(string cpf)
        {
            return _context.UserProfile.FirstOrDefaultAsync(c => c.Cpf.Number == cpf);
        }

        public void Add(UserProfile userProfile)
        {
         _context.UserProfile.Add(userProfile);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
