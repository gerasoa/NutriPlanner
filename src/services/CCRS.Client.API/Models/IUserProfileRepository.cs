using CCRS.Core.DomainObjects;

namespace CCRS.User.API.Models
{
    public interface IUserProfileRepository: IRepository<UserProfile>
    {
        void Add(UserProfile userProfile);
        Task<IEnumerable<UserProfile>> GetAll();
        Task<UserProfile> GetByCpfAsync(string cpf);
        Task<UserProfile> GetByIdAsync(Guid id);      
        Task<UserProfileDetailsViewModel> Update(UserProfileDetailsViewModel userProfileViewModel);      
    }
}
