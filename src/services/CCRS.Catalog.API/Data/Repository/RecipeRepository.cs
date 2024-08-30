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
            return await _context.Recipe.AsNoTracking().ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(Guid id)
        {
            var recipe = await _context.Recipe
                         .Include(v => v.Feedbacks)
                         .Include(r => r.DirectionsGroup)
                         .ThenInclude(ig => ig.Ingredients)
                         .ThenInclude(m => m.Measure)
                         .Include(r => r.DirectionsGroup)
                         .ThenInclude(pg => pg.Directions)
                         .Include(c => c.Category)
                         .Include(c => c.Difficulty)
                         .FirstOrDefaultAsync(r => r.Id == id);

            if(recipe == null)
            {
                return null;    
            }

            recipe.DirectionsGroup = recipe.DirectionsGroup.OrderBy(dg => dg.OrderNumber).ToList();

            foreach(var directionsGroup in recipe.DirectionsGroup)
            {
                directionsGroup.Directions = directionsGroup.Directions.OrderBy(d => d.OrderNumber).ToList();
            }

            return recipe;

        }

        public void Update(Recipe recipe)
        {
            _context.Recipe.Update(recipe);
        }

        public void Add(Recipe recipe)
        {
            _context.Recipe.Add(recipe);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
