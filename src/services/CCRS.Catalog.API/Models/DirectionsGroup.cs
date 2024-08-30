using CCRS.Core.DomainObjects;

namespace CCRS.Catalog.API.Models
{
    public class DirectionsGroup : Entity
    {
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }
    }
}