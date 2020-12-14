namespace DiseaseConfirmer.Web.ViewModels.Complaints
{
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class ComplaintInputModel : IMapFrom<Complaint>
    {
        [Required]
        public string Content { get; set; }
    }
}
