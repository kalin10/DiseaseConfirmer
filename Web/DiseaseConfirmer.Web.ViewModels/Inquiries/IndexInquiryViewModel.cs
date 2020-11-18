namespace DiseaseConfirmer.Web.ViewModels.Inquiries
{
    using System;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class IndexInquiryViewModel : IMapFrom<Inquiry>
    {
        public DateTime CreatedOn { get; set; }

        public string Heading { get; set; }

        public string Symptoms { get; set; }

        public string Url => $"/i/{this.Heading?.Replace(' ', '-')}";
    }
}