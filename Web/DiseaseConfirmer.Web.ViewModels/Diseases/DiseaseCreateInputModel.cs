namespace DiseaseConfirmer.Web.ViewModels.Diseases
{
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class DiseaseCreateInputModel : IMapTo<Disease>
    {
        public string Name { get; set; }

        public string Symptoms { get; set; }

        public string Description { get; set; }

        public string Тreatment { get; set; }

        public string Cause { get; set; }
    }
}
