using MediatR;

namespace CCRS.User.API.Models.Application.Events
{
    public class UserProfessionalEventHandler : INotificationHandler<UserProfessionalRegisteredEvent>
    {
        public Task Handle(UserProfessionalRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //Enviar evento de confirmacao
            return Task.CompletedTask;
        }
    }
}
