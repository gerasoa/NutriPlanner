using CCRS.Core.Messages;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;

namespace CCRS.User.API.Models.Application.Commands
{
    //Um command tem a intencao de alteracao do estado da entidade
    // baseado no construtor do UserRegister
    public class UserRegisterCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string NumCertifiction { get; private set; }
        public string CountryCertification { get; private set; }

        public UserRegisterCommand(Guid id, string name, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new UserRegisterValidation().Validate(this);

            return ValidationResult.IsValid; ;
        }

        // classe aninhada -  classe dentro de outra classe, neste caso por ser co-dependente
        public class UserRegisterValidation : AbstractValidator<UserRegisterCommand>
        {
            public UserRegisterValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Invalid UserProfile Id");

                RuleFor(c => c.Id)
                    .NotEmpty()
                    .WithMessage("The UserProfile name is missing");

                RuleFor(c => c.Cpf)
                    .Must(IsValidCpf)
                    .WithMessage("The CPF provided is not valid");

                RuleFor(c => c.Email)
                   .Must(IsValidEmail)
                   .WithMessage("The e-mail provided is not valid");
            }

            protected static bool IsValidCpf(string cpf)
            {
                return Core.DomainObjects.Cpf.IsValidCpf(cpf);
            }

            protected static bool IsValidEmail(string email)
            {
                return Core.DomainObjects.Email.IsValid(email);
            }
        }
    }
}
