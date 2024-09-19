using CCRS.Core.Messages;
using CCRS.User.API.Models.Application.Events;
using CCRS.User.API.Models.Models;
using FluentValidation.Results;
using MediatR;
using System.Globalization;

namespace CCRS.User.API.Models.Application.Commands
{
    public class UserCommandHandler : CommandHandler, IRequestHandler<UserRegisterCommand, ValidationResult>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserCommandHandler(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<ValidationResult> Handle(UserRegisterCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var userProfile = new UserProfile(message.Id, message.Name, message.Email, message.Cpf);

            //Validacoes de negocio
            var userProfileExistis = await _userProfileRepository.GetByCpf(userProfile.Cpf.Number);

            //persistir no banco de dados
            if (userProfileExistis != null)// ja existe cliente com o cpf informado
            {
                AdddError("This CPF is currently in use.");
                return ValidationResult;
            }

            _userProfileRepository.Add(userProfile);

            userProfile.AddEvent(new UserProfileRegisteredEvent(message.Id, message.Name, message.Email, message.Cpf));

            return await SaveData(_userProfileRepository.UnifOfWork);   
        }
    }
}
