using CCRS.Core.DomainObjects;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class Feedback : Entity
    {
        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navegação para Recipe
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
        

        // Navegação para User (caso tenha a entidade User definida)
        //public User User { get; set; }
    }
}