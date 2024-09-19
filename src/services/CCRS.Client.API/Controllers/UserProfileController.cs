using CCRS.Core.Mediator;
using CCRS.User.API.Models.Application.Commands;
using CCRS.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CCRS.User.API.Models.Controllers
{
    public class UserProfileController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public UserProfileController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("UserProfile")]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler.SendCommand(new UserRegisterCommand(
                Guid.NewGuid(), "Rogerio", "teste@teste.com", "19527091802"));

            return CustomResponse(result);
        }
    }
}
