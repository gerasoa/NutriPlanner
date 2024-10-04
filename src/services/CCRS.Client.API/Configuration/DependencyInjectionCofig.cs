using CCRS.Core.Mediator;
using CCRS.User.API.Models.Application.Commands;
using CCRS.User.API.Models.Application.Events;
using CCRS.User.API.Models.Data;
//using CCRS.User.API.Models.Models;
using CCRS.User.API.Services;
using FluentValidation.Results;
using MediatR;

namespace CCRS.User.API.Models.Configuration
{
    public static class DependencyInjectionCofig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<UserRegisterCommand, ValidationResult>, UserProfessionalCommandHandler>();

            services.AddScoped<INotificationHandler<UserProfessionalRegisteredEvent>, UserProfessionalEventHandler>(); 

            services.AddScoped<IUserProfessionalRepository, UserProfessionalRepository>();
            services.AddScoped<UserProfessionalContext>();

            // nao sera mais utilizado, estara sob responsabilidade da abstracao MessageBus
            // CCRS.User.API.Configuration.MessageBusConfig.AddMessageBusConfiguration
            //services.AddHostedService<UserRegisteredIntegrationHandler>();
        }
    }
}
