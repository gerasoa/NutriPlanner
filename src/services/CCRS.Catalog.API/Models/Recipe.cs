using CCRS.Core.DomainObjects;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Text.Json.Serialization;

namespace CCRS.Catalog.API.Models
{
    public class Recipe : IAggregateRoot //: Entity, IAggregateRoot
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }        
        public string Summary { get; set; }
        public int PublishedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool Active { get; set; }
        public bool Verified { get; set; }    
        public virtual Category Category { get; set; }
        public virtual Difficulty Difficulty { get; set; }


        // EF - Navigation
        [JsonIgnore]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual int DifficultyId { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<RecipeDirection> RecipeDirections { get; set; } = new List<RecipeDirection>();
               
    }
}
