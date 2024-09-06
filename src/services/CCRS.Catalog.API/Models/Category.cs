using CCRS.Core.DomainObjects;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //EF
        [JsonIgnore]
        public virtual ICollection<Recipe> Recipe { get; set; } = new List<Recipe>();
    }
}