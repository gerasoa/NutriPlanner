using CCRS.Catalog.API.Data.Repository;
using CCRS.Catalog.API.Data;
using CCRS.Catalog.API.Models;
using System.Runtime.CompilerServices;

namespace CCRS.Catalog.API.Configuration
{
    public static class DependencyInjectionCofig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<CatalogContext>();
        }
    }
}
