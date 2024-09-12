namespace CCRS.WebApp.MVC.Models
{
    public class IngredientDirectionsViewModel
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }

        public virtual RecipeDirectionViewModel RecipeDirection { get; set; }

        public virtual IngredientMeasureViewModel IngredientMeasure { get; set; }
    }
}