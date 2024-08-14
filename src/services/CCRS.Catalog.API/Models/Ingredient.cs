namespace CCRS.Catalog.API.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Measure Measure { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}