namespace DiseaseConfirmer.Web.ViewModels.Diseases
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class EditDiseaseInputModel : IMapFrom<Disease>, IMapTo<Disease>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required(minimum 4 characters)")]
        [MinLength(4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Symptoms are required")]
        public string Symptoms { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string Тreatment { get; set; }

        public string Cause { get; set; }
    }
}
