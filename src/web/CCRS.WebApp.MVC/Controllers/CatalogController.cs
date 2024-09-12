using CCRS.WebApp.MVC.Models;
using CCRS.WebApp.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCRS.WebApp.MVC.Controllers
{
    public class CatalogController : MainController
    {
        private readonly ICatalogService _catalogoseService;

        public CatalogController(ICatalogService catalogoseService)
        {
            _catalogoseService = catalogoseService;
        }

        [HttpGet]
        [Route("")]
        [Route("catalog")]
        public async Task<IActionResult> Index()
        {
            var recipes = await _catalogoseService.GetAll();

            return View(recipes);
        }

        [HttpGet]
        [Route("recipe-detail/{id}")]
        public async Task<IActionResult> RecipeDetail(int id)
        {
            var recipe = await _catalogoseService.GetById(id);

            return View(recipe);
        }
    }
}
