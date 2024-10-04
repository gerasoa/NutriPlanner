using CCRS.Core.Mediator;
using CCRS.User.API.Models.Application.Commands;
//using CCRS.User.API.Models.Models;
using CCRS.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Polly.Bulkhead;

namespace CCRS.User.API.Models.Controllers
{  
    [ApiController]
    //[Route("api/user-profile")]
    public class UserProfileController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileController(
            IMediatorHandler mediatorHandler, 
            IUserProfileRepository userProfileRepository)
        {
            _mediatorHandler = mediatorHandler;
            _userProfileRepository = userProfileRepository;
        }

        //[HttpGet("UserProfile")]
        //public async Task<IActionResult> Index()
        //{
        //    var result = await _mediatorHandler.SendCommand(new UserRegisterCommand(
        //        Guid.NewGuid(), "Rogerio", "teste@teste.com", "19527091802"));

        //    return CustomResponse(result);
        //}

        [HttpPatch("User/Detail/{id:guid}")]
        public async Task<IActionResult> Update(Guid id,  UserProfileDetailsViewModel userProfileViewModel)
        {
            if (!ModelState.IsValid) { return View(userProfileViewModel); }

            if (id != userProfileViewModel.Id) { return NotFound("The provided ID does not match the user profile."); }

            try
            {
                var result = await _userProfileRepository.Update(userProfileViewModel);
                return CustomResponse(result);
            }
            catch (Exception)
            {
                return CustomResponse(userProfileViewModel);
            }                   
        }

        [HttpGet("User/Detail/{id:guid}")]
        public async Task<ActionResult<UserProfileDetailsViewModel>> GetById(Guid id)
        {
            var userProfile =  await _userProfileRepository.GetByIdAsync(id);

            if (userProfile == null) { return NotFound("User profile not found."); }

            var userProfiledetail =  new UserProfileDetailsViewModel
            {
                Id = userProfile.Id,
                NutritionistCouncilNumber = userProfile.NutritionistCouncilNumber,
                CountryOfCertification = userProfile.CountryOfCertification,
                Nacionality = userProfile.Nacionality                
            };

            return Ok(userProfiledetail);
        }
    }
}
