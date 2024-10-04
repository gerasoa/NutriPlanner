using CCRS.Core.DomainObjects;
using System.Diagnostics;

namespace CCRS.User.API.Models
{
    public class UserProfessional : Entity, IAggregateRoot
    {
        public UserProfessional(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            IsActive = true;
        }
           
        //EF Relation
        public UserProfessional()
        {

        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public string NutritionistCouncilNumber { get; private set; }
        public string CountryOfCertification { get; private set; }
        public bool IsActive { get; private set; } // 0 = False - 1 = True
        public Address Address { get; private set; }
        public string Profession { get; private set; }
        public string Nacionality { get; private set; }
        public DateOnly DoB { get; private set; }
        public string Gender { get; private set; }
        public string Phone { get; private set; }

        public void ChangeEmail(string email) 
        {
            Email = new Email(email);
        }
        public void SetAddress(Address address)
        {
            Address = address;
        }

        public void SetNutritionistCouncilNumber(string nutritionistCouncilNumber)
        {
            if(!string.IsNullOrEmpty(nutritionistCouncilNumber))
            {
                NutritionistCouncilNumber = nutritionistCouncilNumber.Trim();
            }
        }

        public void SetCountryOfCertification(string countryOfCertification)
        {
            if (!string.IsNullOrEmpty(countryOfCertification))
            {
                CountryOfCertification = countryOfCertification.Trim();
            }
        }

        public void SetNacionality(string nacionality)
        {
            if (!string.IsNullOrEmpty(nacionality))
            {
                Nacionality = nacionality.Trim();
            }
        }
    }
}
