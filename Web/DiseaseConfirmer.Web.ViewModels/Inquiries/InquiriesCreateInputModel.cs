namespace DiseaseConfirmer.Web.ViewModels.Inquiries
{
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class InquiriesCreateInputModel : IMapTo<Inquiry>
    {
        [Required(ErrorMessage = "Heading is required")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Symptoms are required")]
        public string Symptoms { get; set; }

        public string DetailedInformation { get; set; }
    }
}
