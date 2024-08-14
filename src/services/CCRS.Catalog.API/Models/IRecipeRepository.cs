using CCRS.Core.DomainObjects;

namespace CCRS.Catalog.API.Models
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(Guid id);

        void Add(Recipe recipe);
        void Update(Recipe recipe);
    }
}
