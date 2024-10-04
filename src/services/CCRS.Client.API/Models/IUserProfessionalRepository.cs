using CCRS.Core.DomainObjects;

namespace CCRS.User.API.Models
{
    public interface IUserProfessionalRepository: IRepository<UserProfessional>
    {
        void Add(UserProfessional userProfessional);
        Task<IEnumerable<UserProfessional>> GetAll();
        Task<UserProfessional> GetByCpfAsync(string cpf);
        Task<UserProfessional> GetByIdAsync(Guid id);      
        Task<UserProfessionalDetailsViewModel> Update(UserProfessionalDetailsViewModel userProfessionalViewModel);      
    }
}
