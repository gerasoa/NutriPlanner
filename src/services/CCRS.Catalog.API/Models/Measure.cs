using CCRS.Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class Measure   
    {
        public int Id { get; set; }
        public string UnitShort { get; set; }
        public string UnitLong { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public virtual List<IngredientMeasure> IngredientMeasure { get; internal set; }

    }
}