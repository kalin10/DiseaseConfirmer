namespace DiseaseConfirmer.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Common.Models;

    public class Inquiry : BaseDeletableModel<int>
    {
        public Inquiry()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string Symptoms { get; set; }

        public string DetailedInformation { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
