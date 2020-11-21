namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class CategoryCreateInputModel : IMapTo<Category>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
