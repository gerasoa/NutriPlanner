using CCRS.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class RecipeDirection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        //EF - Navigation
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
        [JsonIgnore]
        public virtual int RecipeId { get; set; }
        
        public ICollection<IngredientDirection> IngredientDirections { get; set; } = new List<IngredientDirection>();

        public ICollection<Direction> Directions{ get; set; } = new List<Direction>();        
    }
}