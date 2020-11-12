namespace DiseaseConfirmer.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DiseaseConfirmer.Data.Common.Models;

    public class Inquiry : BaseDeletableModel<int>
    {
        public Inquiry()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Heading { get; set; }

        public string Symptoms { get; set; }

        public string DetailedInformation { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
