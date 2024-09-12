namespace CCRS.WebApp.MVC.Models
{
    public class RecipeDirectionsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreatedAt { get; set; }


        public List<IngredientDirectionsViewModel> ingredientDirections { get; set; }
        public List<DirectionsViewModel> Directions { get; set; }

    }
}
