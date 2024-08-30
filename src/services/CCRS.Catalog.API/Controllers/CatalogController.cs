using CCRS.Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CCRS.Catalog.API.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;

        public CatalogController(IRecipeRepository productRepository)
        {
            _recipeRepository = productRepository;
        }

        [HttpGet("catalog/recipes")]
        public async Task<IEnumerable<Recipe>> Index()
        {
            return await _recipeRepository.GetAllRecipesAsync();          
        }

        [HttpGet("catalog/recipes/{id}")]
        public async Task<Recipe> RecipeDetail(Guid id)
        {            
            return await _recipeRepository.GetRecipeByIdAsync(id);
        }
    }
}
