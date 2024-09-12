namespace CCRS.WebApp.MVC.Models
{
    public class IngredientMeasureViewModel
    {
        public int Id { get; set; }
        public MeasureViewModel Measure { get; set; }
        public IngredientViewModel Ingredient { get; set; }
    }
}