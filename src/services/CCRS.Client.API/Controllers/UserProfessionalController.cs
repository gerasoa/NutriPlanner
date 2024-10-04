using CCRS.Core.Mediator;
using CCRS.User.API.Models.Application.Commands;
//using CCRS.User.API.Models.Models;
using CCRS.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Polly.Bulkhead;

namespace CCRS.User.API.Models.Controllers
{  
    [ApiController]
    //[Route("api/user-Professional")]
    public class UserProfessionalController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUserProfessionalRepository _userProfessionalRepository;

        public UserProfessionalController(
            IMediatorHandler mediatorHandler, 
            IUserProfessionalRepository userProfessionalRepository)
        {
            _mediatorHandler = mediatorHandler;
            _userProfessionalRepository = userProfessionalRepository;
        }

        //[HttpGet("UserProfessional")]
        //public async Task<IActionResult> Index()
        //{
        //    var result = await _mediatorHandler.SendCommand(new UserRegisterCommand(
        //        Guid.NewGuid(), "Rogerio", "teste@teste.com", "19527091802"));

        //    return CustomResponse(result);
        //}

        [HttpPatch("User/Detail/{id:guid}")]
        public async Task<IActionResult> Update(Guid id,  UserProfessionalDetailsViewModel userProfessionalViewModel)
        {
            if (!ModelState.IsValid) { return View(userProfessionalViewModel); }

            if (id != userProfessionalViewModel.Id) { return NotFound("The provided ID does not match the user Professional."); }

            try
            {
                var result = await _userProfessionalRepository.Update(userProfessionalViewModel);
                return CustomResponse(result);
            }
            catch (Exception)
            {
                return CustomResponse(userProfessionalViewModel);
            }                   
        }

        [HttpGet("User/Detail/{id:guid}")]
        public async Task<ActionResult<UserProfessionalDetailsViewModel>> GetById(Guid id)
        {
            var userProfessional =  await _userProfessionalRepository.GetByIdAsync(id);

            if (userProfessional == null) { return NotFound("User Professional not found."); }

            var userProfessionaldetail =  new UserProfessionalDetailsViewModel
            {
                Id = userProfessional.Id,
                NutritionistCouncilNumber = userProfessional.NutritionistCouncilNumber,
                CountryOfCertification = userProfessional.CountryOfCertification,
                Nacionality = userProfessional.Nacionality                
            };

            return Ok(userProfessionaldetail);
        }
    }
}
