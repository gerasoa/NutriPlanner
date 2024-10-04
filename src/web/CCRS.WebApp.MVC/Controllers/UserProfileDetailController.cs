using CCRS.WebApp.MVC.Models;
using CCRS.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CCRS.WebApp.MVC.Controllers
{
    public class UserProfileDetailController : MainController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileDetailController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        [Route("user-profile/detail/{id:guid}")]
        public async Task<IActionResult> Index(Guid id)
        {
            var user = await _userProfileService.GetById(id);

            return View(user);
        }

        [HttpPost]
        [Route("user-profile/detail/{id:guid}")]
        public IActionResult Index(Guid id, UserProfileDetailsViewModel userProfileDetailsViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "The submitted data is not valid.";
                return View(userProfileDetailsViewModel);
            }

            if (id != userProfileDetailsViewModel.Id)
            {
                TempData["ErrorMessage"] = "The provided ID does not match the user profile.";
                return View(userProfileDetailsViewModel);
            }

            var response = _userProfileService.Update(userProfileDetailsViewModel);

            if (!response.IsFaulted)
            {
                TempData["SuccessMessage"] = "User profile updated successfully!";
                return RedirectToAction("Index", new { id = userProfileDetailsViewModel.Id });
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update the user profile. Please try again.";
                return View(userProfileDetailsViewModel);
            }
        }
    }
}
