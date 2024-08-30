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
        public DateTime CreatedDate { get; set; }

        //[JsonIgnore]
        //public virtual Ingredient Ingredient { get; internal set; }

        //[ForeignKey("Ingredient")]
        //public int Id { get; set; }
    }
}