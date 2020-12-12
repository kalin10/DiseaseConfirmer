namespace DiseaseConfirmer.Web.ViewModels.Diseases
{
    using System.Linq;

    using AutoMapper;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class DiseaseViewModel : IMapFrom<Disease>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symptoms { get; set; }

        public string Description { get; set; }

        public string Тreatment { get; set; }

        public string Cause { get; set; }

        public string CategoryName { get; set; }

        public int VotesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Disease, DiseaseViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
