namespace DiseaseConfirmer.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Diseases = new HashSet<Disease>();
            this.Doctors = new HashSet<ApplicationUser>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }

        public virtual ICollection<ApplicationUser> Doctors { get; set; }
    }
}
