using CCRS.Core.DomainObjects;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class IngredientMeasure
    {
        public int Id { get; set; }


        //EF
        [JsonIgnore]
        public virtual ICollection<IngredientDirection> IngredientDirections { get; set; }

        [JsonIgnore]
        public virtual int MeasureId { get; set; }      
        public virtual Measure Measure { get; set; }


        [JsonIgnore]
        public virtual int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }









    }
}