namespace DiseaseConfirmer.Web.ViewModels.Inquiries
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class InquiriesCreateInputModel : IMapTo<Inquiry>
    {
        public string Heading { get; set; }

        public string Symptoms { get; set; }

        public string DetailedInformation { get; set; }
    }
}
