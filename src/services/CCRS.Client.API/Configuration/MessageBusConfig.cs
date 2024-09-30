using CCRS.Core.Tools;
using CCRS.MessageBus;
using CCRS.User.API.Services;
using System.Runtime.CompilerServices;

namespace CCRS.User.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<UserRegisteredIntegrationHandler>();
        }
    }
}
