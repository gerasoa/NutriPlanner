using CCRS.Catalog.API.Models;
using CCRS.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CCRS.Catalog.API.Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CatalogContext _context;

        public RecipeRepository(CatalogContext context)
        {
            _context = context;
        }

        public IUnifOfWork UnifOfWork => _context;

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes.AsNoTracking().ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            var recipe = await _context.Recipes
                         .Include(v => v.Feedbacks)
                         .Include(c => c.Category)
                         .Include(c => c.Difficulty)
                         .Include(r => r.RecipeDirections)
                            .ThenInclude(ig => ig.IngredientDirections)
                            .ThenInclude(m => m.IngredientMeasure)
                            .ThenInclude(pg => pg.Ingredient)
                        .Include(r => r.RecipeDirections)
                            .ThenInclude(ig => ig.IngredientDirections)
                            .ThenInclude(m => m.IngredientMeasure)
                            .ThenInclude(pg => pg.Measure)
                        .Include(r => r.RecipeDirections)
                            .ThenInclude(d => d.Directions)
                        .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return null;
            }

            recipe.RecipeDirections = recipe.RecipeDirections.OrderBy(dg => dg.OrderNumber).ToList();

            foreach (var directionsGroup in recipe.RecipeDirections)
            {
                directionsGroup.Directions = directionsGroup.Directions.OrderBy(d => d.OrderNumber).ToList();
            }

            return recipe;

        }

        public void Update(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
        }

        public void Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
