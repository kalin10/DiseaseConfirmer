namespace DiseaseConfirmer.Web.ViewModels.Doctors
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class IndexDoctorViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CareerInfoWorkplace { get; set; }

        public string CareerInfoDegrees { get; set; }

        public string CareerInfoExperience { get; set; }

        public string CareerInfoAwards { get; set; }
    }
}