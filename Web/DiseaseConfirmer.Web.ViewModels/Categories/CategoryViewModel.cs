namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AddDiseaseButtonUrl => $"/d/{this.Name?.Replace(' ', '-')}/Add";

        public IEnumerable<DiseaseInCategoryViewModel> Diseases { get; set; }
    }
}
