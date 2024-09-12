using CCRS.WebApp.MVC.Models;
using System.Collections.Generic;

namespace CCRS.WebApp.MVC.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<RecipeViewModel>> GetAll();
        Task<RecipeViewModel> GetById(int id);
    }
}
