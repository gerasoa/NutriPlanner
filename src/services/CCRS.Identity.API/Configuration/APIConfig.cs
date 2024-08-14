using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;
using CCRS.WebAPI.Core.Identity;

namespace CCRS.Identity.API.Configuration
{
    public static class APIConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddControllers();            

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
            }            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthConfiguration();
            
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
