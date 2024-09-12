using CCRS.Catalog.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;
using CCRS.WebAPI.Core.Identity;
using static CCRS.WebAPI.Core.Identity.CustomAuthorize;
//using CCRS.Identity.API.Models;

namespace CCRS.Catalog.API.Controllers
{
    [ApiController]
    [Authorize]
    public class CatalogController : Controller
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
