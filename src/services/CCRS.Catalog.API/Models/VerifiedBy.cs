using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CCRS.Catalog.API.Models
{
    public class VerifiedBy
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Review Review { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}