
using CCRS.Core.Mediator;
using CCRS.Core.Messages.Integration;
using CCRS.MessageBus;
using CCRS.User.API.Models.Application.Commands;
using CCRS.User.API.Models.Application.Events;
using FluentValidation.Results;
using System.Runtime.CompilerServices;

namespace CCRS.User.API.Services
{
    public class UserRegisteredIntegrationHandler : BackgroundService
    {
        //private IBus _bus;
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public UserRegisteredIntegrationHandler(
            IServiceProvider serviceProvider, 
            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Ao excluir o RabbitMQ add MessageBus e ele ja contem a string de conexao
            //_bus = RabbitHutch.CreateBus("host=localhost:5672");

            var success = _bus.RespondAsync<UserRegisteredIntegrationEvent, ResponseMessage>(async request =>
            await RegisterUser(request));

            return Task.CompletedTask;
        }

        private async Task<ResponseMessage> RegisterUser(UserRegisteredIntegrationEvent message)
        {
            var userCommand = new UserRegisterCommand(message.Id, message.Name, message.Email, message.CPF);

            ValidationResult success;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                success = await mediator.SendCommand(userCommand);
            }

            return new ResponseMessage(success);
        }
    }
}
