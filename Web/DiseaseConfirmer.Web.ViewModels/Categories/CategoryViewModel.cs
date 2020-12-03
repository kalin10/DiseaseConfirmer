namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;
    using DiseaseConfirmer.Web.ViewModels.Diseases;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AddDiseaseButtonUrl => $"/d/{this.Name?.Replace(' ', '-')}/Add";

        public IEnumerable<DiseaseViewModel> Diseases { get; set; }
    }
}
