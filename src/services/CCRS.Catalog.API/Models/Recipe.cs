using CCRS.Core.DomainObjects;

namespace CCRS.Catalog.API.Models
{
    public class Recipe : Entity, IAggregateRoot
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        public string Image { get; set; }
        public Difficulty Difficulty { get; set; }
        public string Summary { get; set; }
        public int PublishedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public bool Verified { get; set; }
        public List<DirectionsGroup> DirectionsGroup { get; set; } = new List<DirectionsGroup>();
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public int CategoryId { get; set; }
    }
}
