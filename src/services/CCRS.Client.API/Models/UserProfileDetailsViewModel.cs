namespace CCRS.User.API.Models
{
    public class UserProfileDetailsViewModel
    {
        public Guid Id { get; set; }
        public string NutritionistCouncilNumber { get; set; }
        public string CountryOfCertification { get; set; }
        public string Profession { get; set; }
        public string Nacionality { get; set; }
        public DateOnly DoB { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
    }

}
