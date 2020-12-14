namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class EditCategoryInputModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required(minimum 4 characters)")]
        [MinLength(4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
