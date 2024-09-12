namespace CCRS.WebApp.MVC.Models
{
    public class RecipeDirectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<IngredientDirectionsViewModel> IngredientDirections { get; set; }

        public ICollection<DirectionsViewModel> Directions { get; set; }
    }
}