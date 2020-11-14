namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class DiseaseInCategoryViewModel : IMapFrom<Disease>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}
