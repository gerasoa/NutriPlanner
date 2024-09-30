using CCRS.Core.Messages.Integration;
using CCRS.MessageBus;
using CCRS.WebAPI.Core.Controllers;
using CCRS.WebAPI.Core.Identity;
using EasyNetQ;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static CCRS.Identity.API.Models.UserViewModels;

namespace CCRS.Identity.API.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class AuthController : MainController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppSettings _appSettings;
        //private IBus _bus;
        private readonly IMessageBus _bus;

        public AuthController(SignInManager<IdentityUser> signInManager,
                                            UserManager<IdentityUser> userManager,
                                            IOptions<AppSettings> appSettings,
                                            IMessageBus bus)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _bus = bus;
        }

        [HttpPost("new-user")]
        public async Task<ActionResult> Register(UserRegister userRegister)
        {
            //return new StatusCodeResult(500);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = userRegister.Email,
                Email = userRegister.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                //Build the integration event
                var userResult = await ClientRegister(userRegister);

                if(!userResult.ValidationResult.IsValid)
                {
                    await _userManager.DeleteAsync(user);
                    return CustomResponse(userResult.ValidationResult);
                }

                return Ok(await GenerateJwt(userRegister.Email));
            }

            foreach (var error in result.Errors)
            {
                AddProcessingError(error.Description);
            }

            return CustomResponse();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GenerateJwt(userLogin.Email));
            }

            if (result.IsLockedOut)
            {
                AddProcessingError("User temporarily blocked by invalid attempts");
                return CustomResponse();
            }

            AddProcessingError("Invalid user or password");
            return CustomResponse();
        }

        private async Task<UserResponseLogin> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await GetUserClaims(user, claims);
            var encodedToken = EncodeToken(identityClaims);
            var userRoles = await _userManager.GetRolesAsync(user);

            return GetResponseToken(user, claims, encodedToken);
        }

        private UserResponseLogin GetResponseToken(IdentityUser user, IList<Claim> claims, string encodedToken)
        {
            return new UserResponseLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpirationInHours).TotalSeconds,
                UserToken = new UserToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UserClaim { Type = c.Type, Value = c.Value })
                }
            };
        }

        private string EncodeToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidIn,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private async Task<ClaimsIdentity> GetUserClaims(IdentityUser user, IList<Claim> claims)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixExpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixExpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            return identityClaims;
        }

        private static long ToUnixExpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        //recebe o request e ja devolve o response
        private async Task<ResponseMessage> ClientRegister(UserRegister userRegister)
        {
            var user = await _userManager.FindByEmailAsync(userRegister.Email);

            var userRegistered = new UserRegisteredIntegrationEvent(
                Guid.Parse(user.Id), userRegister.Name, userRegister.Email, userRegister.Cpf);
                        
            try
            {
                // Default port RabbitMQ
                // _bus = RabbitHutch.CreateBus("host=localhost:5672");
                return await _bus.RequestAsync<UserRegisteredIntegrationEvent, ResponseMessage>(userRegistered);
            }
            catch 
            {
                await _bus.RequestAsync<UserRegisteredIntegrationEvent, ResponseMessage>(userRegistered);
                throw;
            }                        
        }
    }
}
