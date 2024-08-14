using CCRS.WebApp.MVC.Extensions;
using CCRS.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace CCRS.WebApp.MVC.Services
{

    public class AuthenticationService : Service, IAuthenticationService
    {
        private readonly HttpClient _httpClient;
 
        public AuthenticationService(HttpClient httpClient, 
                                    IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AuthenticationUrl);

            _httpClient = httpClient;
        }

        public async Task<UserLoginResponse> Login(UserLogin userLogin)
        {
            var loginContent = GetContent(userLogin);

            var response = await _httpClient.PostAsync("/api/identity/login", loginContent);

            if (!HandleErrorsResponse(response))
            {
                return new UserLoginResponse
                {
                    ResponseResult = await DeserializeReturnMessage<ResponseResult>(response)
                };
            }

            return await DeserializeReturnMessage<UserLoginResponse>(response);
        }

        public async Task<UserLoginResponse> Register(UserRegister userRegister)
        {
            var registerContent = GetContent(userRegister);

            var response = await _httpClient.PostAsync("/api/identity/new-user", registerContent);

            if (!HandleErrorsResponse(response))
            {
                return new UserLoginResponse
                {
                    ResponseResult = await DeserializeReturnMessage<ResponseResult>(response)
                };
            }

            return await DeserializeReturnMessage<UserLoginResponse>(response);
        }
    }
}
