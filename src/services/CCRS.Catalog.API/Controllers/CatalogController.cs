using CCRS.Catalog.API.Models;
using CCRS.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CCRS.WebAPI.Core.Identity.CustomAuthorize;

namespace CCRS.Catalog.API.Controllers
{
    [ApiController]
    [Authorize]
    public class CatalogController : MainController
    {
        private readonly IRecipeRepository _recipeRepository;

        public CatalogController(IRecipeRepository productRepository)
        {
            _recipeRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("Catalog/Recipe")]
        public async Task<IEnumerable<Recipe>> Index()
        {
            return await _recipeRepository.GetAllRecipesAsync();          
        }

        
        [HttpGet]
        [Route("Catalog/Recipe/{id}")]
        [ClaimsAuthorize("Catalog", "Read")]
        public async Task<Recipe> RecipeDetail(int id)
        {            
            return await _recipeRepository.GetRecipeByIdAsync(id);
        }
    }
}
