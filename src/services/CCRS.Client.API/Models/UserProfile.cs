using CCRS.Core.DomainObjects;
using System.Diagnostics;

namespace CCRS.User.API.Models.Models
{
    public class UserProfile : Entity, IAggregateRoot
    {
        public UserProfile(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            IsActive = true;
            
        }

        //EF Relation
        protected UserProfile()
        {

        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public string NumCertifiction {  get; private set; }
        public string CountryCertification { get; private set; }
        public bool IsActive { get; private set; } // 0 = False - 1 = True
        public Address Address { get; private set; }


        public void ChangeEmail(string email) 
        {
            Email = new Email(email);
        }
        public void SetAddress(Address address)
        {
            Address = address;
        }
    }
}
