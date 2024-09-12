namespace CCRS.WebApp.MVC.Models
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
