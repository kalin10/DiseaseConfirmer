namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class CategoryCreateInputModel : IMapTo<Category>
    {
        [Required(ErrorMessage = "Name is required(minimum 4 characters)")]
        [MinLength(4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
