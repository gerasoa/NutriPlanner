using CCRS.Core.DomainObjects;

namespace CCRS.User.API.Models.Models
{
    public interface IUserProfileRepository: IRepository<UserProfile>
    {
        void Add(UserProfile userProfile);
        Task<IEnumerable<UserProfile>> GetAll();
        Task<UserProfile> GetByCpf(string cpf);
    }
}
