using CCRS.Core.DomainObjects;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class Feedback 
    {
        public int Id { get; set; }
        public int UserId { get; set; }        
        public int Stars { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        // EF
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
        [JsonIgnore]
        public virtual int RecipeId { get; set; }


        // Navegação para User (caso tenha a entidade User definida)
        //public User User { get; set; }
    }
}