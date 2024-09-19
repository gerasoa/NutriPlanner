using CCRS.Core.DomainObjects;
using CCRS.Core.Messages;

namespace CCRS.User.API.Models.Application.Events
{
    public class UserProfileRegisteredEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }

        public UserProfileRegisteredEvent(Guid id, string name, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
        }
    }
}

