namespace DiseaseConfirmer.Web.ViewModels.Complaints
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class ComplaintInputModel : IMapFrom<Complaint>
    {
        public string Content { get; set; }
    }
}
