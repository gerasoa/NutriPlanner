using MediatR;

namespace CCRS.User.API.Models.Application.Events
{
    public class UserProfileEventHandler : INotificationHandler<UserProfileRegisteredEvent>
    {
        public Task Handle(UserProfileRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //Enviar evento de confirmacao
            return Task.CompletedTask;
        }
    }
}
