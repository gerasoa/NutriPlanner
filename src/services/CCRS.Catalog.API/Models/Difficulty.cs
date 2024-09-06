using CCRS.Core.DomainObjects;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class Difficulty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //EF - Navigation
        [JsonIgnore]
        public virtual ICollection<Recipe> Recipe { get; set; } = new List<Recipe>();

    }
}