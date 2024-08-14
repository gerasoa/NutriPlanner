using Microsoft.OpenApi.Models;

namespace CCRS.Catalog.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CCRS Catalog API",
                    Description = "This API is part of CCRS MyMeals Application",
                    Contact = new OpenApiContact() { Name = "Rogerio Soares", Email = "contato@ras.com.br" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("htps://opensource.org/licenses/MIT") }
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
            return app;
        }
    }
}
