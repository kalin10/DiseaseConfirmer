namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class CategoryCreateInputModel : IMapTo<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
