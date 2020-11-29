using DiseaseConfirmer.Data.Models;
using DiseaseConfirmer.Services.Mapping;

namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    public class EditCategoryInputModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
