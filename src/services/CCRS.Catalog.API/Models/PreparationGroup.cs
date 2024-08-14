namespace CCRS.Catalog.API.Models
{
    public class PreparationGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<Preparation> Preparations { get; set; }
    }
}