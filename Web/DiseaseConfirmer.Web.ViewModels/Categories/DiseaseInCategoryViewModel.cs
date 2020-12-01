namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class DiseaseInCategoryViewModel : IMapFrom<Disease>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription =>
            this.Description?.Length > 50
             ? this.Description.Substring(0, 50) + "..."
            : this.Description;

        public string Url => $"/d/{this.Name.Replace(' ', '-')}";
    }
}
