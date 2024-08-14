namespace MyMeals.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string? Comment { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}