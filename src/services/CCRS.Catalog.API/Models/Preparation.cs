namespace CCRS.Catalog.API.Models
{
    public class Preparation
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string Step { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}