using CCRS.WebApp.MVC.Models;

namespace CCRS.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<UserLoginResponse> Login(UserLogin userLogin);
        
        Task<UserLoginResponse> Register(UserRegister userRegister);
    }
}
