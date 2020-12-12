namespace DiseaseConfirmer.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Common.Models;

    public class Disease : BaseDeletableModel<int>
    {
        public Disease()
        {
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        public string Name { get; set; }

        public string Symptoms { get; set; }

        public string Description { get; set; }

        public string Тreatment { get; set; }

        public string Cause { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
