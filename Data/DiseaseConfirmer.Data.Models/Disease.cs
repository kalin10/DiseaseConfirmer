namespace DiseaseConfirmer.Data.Models
{
    using DiseaseConfirmer.Data.Common.Models;

    public class Disease : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Symptoms { get; set; }

        public string Description { get; set; }

        public string Тreatment { get; set; }

        public string Cause { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
