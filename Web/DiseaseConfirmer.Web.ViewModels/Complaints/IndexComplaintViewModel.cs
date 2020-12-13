namespace DiseaseConfirmer.Web.ViewModels.Complaints
{
    using System;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class IndexComplaintViewModel : IMapFrom<Complaint>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}