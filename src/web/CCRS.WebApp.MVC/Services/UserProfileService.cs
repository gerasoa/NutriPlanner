using CCRS.WebApp.MVC.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;
using CCRS.WebApp.MVC.Extensions;

namespace CCRS.WebApp.MVC.Services
{
    public class UserProfileService : Service, IUserProfileService
    {
        private readonly HttpClient _httpClient;

        public UserProfileService(HttpClient httpClient, 
                                    IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.UserProfileUrl);

            _httpClient = httpClient;
        }

        public async Task<UserProfileDetailsViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/user/detail/{id}");

            HandleErrorsResponse(response);

            return await DeserializeReturnMessage<UserProfileDetailsViewModel>(response);
        }        

        public async Task<(bool Issuccess, UserProfileDetailsViewModel Result, string Message)> Update(UserProfileDetailsViewModel userProfileDetailsViewModel)
        {
            var userProfileContent = GetContent(userProfileDetailsViewModel);

            var response = await _httpClient.PatchAsync($"/user/detail/{userProfileDetailsViewModel.Id}", userProfileContent);
            
            if (!HandleErrorsResponse(response))
            {
                var errorResult = await DeserializeReturnMessage<UserProfileDetailsViewModel>(response);
                return (false, errorResult, "Falha ao atualizar o perfil.");
            }

            var successResult = await DeserializeReturnMessage<UserProfileDetailsViewModel>(response);
            return (true, successResult, "Perfil atualizado com sucesso.");                     
        }        
    }

    public interface IUserProfileService
    {
        Task<UserProfileDetailsViewModel> GetById(Guid id);
        Task<(bool Issuccess, UserProfileDetailsViewModel Result, string Message)> Update(UserProfileDetailsViewModel userProfileDetailsViewModel);
    }
}
