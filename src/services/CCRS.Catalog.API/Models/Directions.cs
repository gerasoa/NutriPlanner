using CCRS.Core.DomainObjects;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class Direction 
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string Step { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Ef - Navigation

        public int RecipeDirectionId { get; set; }
        [JsonIgnore]
        public RecipeDirection RecipeDirection { get; set; }
    }
}