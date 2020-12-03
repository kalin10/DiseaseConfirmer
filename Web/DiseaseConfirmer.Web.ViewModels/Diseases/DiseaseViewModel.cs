namespace DiseaseConfirmer.Web.ViewModels.Diseases
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class DiseaseViewModel : IMapFrom<Disease>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Symptoms { get; set; }

        public string Description { get; set; }

        public string Тreatment { get; set; }

        public string Cause { get; set; }

        public string CategoryName { get; set; }
    }
}
