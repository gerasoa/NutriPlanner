using CCRS.Core.Messages;
using CCRS.User.API.Models.Application.Events;
//using CCRS.User.API.Models.Models;
using FluentValidation.Results;
using MediatR;
using System.Globalization;

namespace CCRS.User.API.Models.Application.Commands
{
    public class UserProfessionalCommandHandler : CommandHandler, IRequestHandler<UserRegisterCommand, ValidationResult>
    {
        private readonly IUserProfessionalRepository _userProfessionalRepository;

        public UserProfessionalCommandHandler(IUserProfessionalRepository userProfessionalRepository)
        {
            _userProfessionalRepository = userProfessionalRepository;
        }

        public async Task<ValidationResult> Handle(UserRegisterCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var userProfessional = new UserProfessional(message.Id, message.Name, message.Email, message.Cpf);

            //Validacoes de negocio
            var userProfessionalExistis = await _userProfessionalRepository.GetByCpfAsync(userProfessional.Cpf.Number);

            //persistir no banco de dados
            if (userProfessionalExistis != null)// ja existe cliente com o cpf informado
            {
                AddError("This CPF is currently in use.");
                return ValidationResult;
            }

            _userProfessionalRepository.Add(userProfessional);

            userProfessional.AddEvent(new UserProfessionalRegisteredEvent(message.Id, message.Name, message.Email, message.Cpf));

            return await SaveData(_userProfessionalRepository.UnifOfWork);   
        }
    }
}
