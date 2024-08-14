namespace MyMeals.Models
{
    public class VerifiedBy
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Review? Review { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}