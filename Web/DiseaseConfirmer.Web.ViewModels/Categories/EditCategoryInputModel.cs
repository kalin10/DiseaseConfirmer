namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class EditCategoryInputModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
