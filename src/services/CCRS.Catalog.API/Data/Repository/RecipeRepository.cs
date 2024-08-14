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

        public async Task<Recipe> GetRecipeByIdAsync(Guid id)
        {
            return await _context.Recipes.FindAsync(id);
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
