using CCRS.Core.DomainObjects;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //EF
        [JsonIgnore]
        public virtual ICollection<IngredientMeasure> IngredientMeasures { get; set; } = new List<IngredientMeasure>();


    }
}