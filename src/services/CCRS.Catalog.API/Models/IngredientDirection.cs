using CCRS.Core.DomainObjects;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class IngredientDirection 
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }


        //EF - Navigation
        [JsonIgnore]
        public virtual int RecipeDirectionId { get; set; }
        [JsonIgnore]
        public virtual RecipeDirection RecipeDirection { get; set; }


        [JsonIgnore]
        public virtual int IngredientMeasureId { get; set; }
        
        public virtual IngredientMeasure IngredientMeasure { get; set; }
    }
}