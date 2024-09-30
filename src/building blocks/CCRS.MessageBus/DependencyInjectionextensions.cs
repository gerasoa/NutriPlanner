using Microsoft.Extensions.DependencyInjection;

namespace CCRS.MessageBus
{
    public static class DependencyInjectionextensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException();

            services.AddSingleton<IMessageBus>(new MessageBus(connection));

            return services;
        }
    }
}
