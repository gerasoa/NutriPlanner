using CCRS.Core.Tools;
using CCRS.MessageBus;

namespace CCRS.Identity.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));                
        }
    }
}
