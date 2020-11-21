namespace DiseaseConfirmer.Web.ViewModels.Inquiries
{
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class InquiriesCreateInputModel : IMapTo<Inquiry>
    {
        [Required]
        public string Heading { get; set; }

        [Required]
        public string Symptoms { get; set; }

        public string DetailedInformation { get; set; }
    }
}
