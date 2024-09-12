using CCRS.WebApp.MVC.Extensions;
using CCRS.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace CCRS.WebApp.MVC.Services
{
    public class CatalogService : Service, ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient,
                                    IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CatalogUrl);

            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RecipeViewModel>> GetAll() 
        {
            var response = await _httpClient.GetAsync("/catalog/recipe");

            HandleErrorsResponse(response);

            return await DeserializeReturnMessage<IEnumerable<RecipeViewModel>>(response);
        }

        public async Task<RecipeViewModel> GetById(int id)
        {
            var response = await _httpClient.GetAsync($"/catalog/recipe/{id}");

            HandleErrorsResponse(response);

            return await DeserializeReturnMessage<RecipeViewModel>(response);
        }
    }
}
