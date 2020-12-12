namespace DiseaseConfirmer.Web.ViewModels.Inquiries
{
    using System;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class IndexInquiryViewModel : IMapFrom<Inquiry>
    {
        public int Id { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Heading { get; set; }

        public string Symptoms { get; set; }

        public string ShortSymptoms =>
            this.Symptoms?.Length > 50
             ? this.Symptoms.Substring(0, 50) + "..."
            : this.Symptoms;
    }
}