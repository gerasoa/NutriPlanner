namespace CCRS.WebApp.MVC.Models
{
    public class RecipeViewModel
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
        public CategoryViewModel Category { get; set; }
        public DifficultyViewModel Difficulty { get; set; }
        public List<FeedbackViewModel> Feedbacks { get; set; }
        public List<RecipeDirectionsViewModel> RecipeDirections { get; set; }
    }
}
