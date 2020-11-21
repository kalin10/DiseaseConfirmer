namespace DiseaseConfirmer.Web.ViewModels.Diseases
{
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class DiseaseCreateInputModel : IMapTo<Disease>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Symptoms { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Тreatment { get; set; }

        [Required]
        public string Cause { get; set; }
    }
}
