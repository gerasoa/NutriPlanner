namespace MyMeals.Models
{
    public class IngredientGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<Ingredient> Ingredient { get; set; }
    }
}