namespace DiseaseConfirmer.Web.ViewModels.Categories
{
    using AutoMapper;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";

        //public string Url { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Category, CategoryViewModel>()
        //        .ForMember
        //        (
        //        x => x.Url, 
        //        c => c.MapFrom(e => "/f/" + e.Id.ToString() + "/" + e.Name.Replace(' ', '-')));
        //}
    }
}
