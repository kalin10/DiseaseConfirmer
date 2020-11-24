namespace DiseaseConfirmer.Web.ViewModels.Inquiries
{
    using System;
    using System.Collections.Generic;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class InquiryViewModel : IMapFrom<Inquiry>
    {
        public int Id { get; set; }

        public string Heading { get; set; }

        public string Symptoms { get; set; }

        public string DetailedInformation { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<InquiryCommentViewModel> Comments { get; set; }
    }
}
