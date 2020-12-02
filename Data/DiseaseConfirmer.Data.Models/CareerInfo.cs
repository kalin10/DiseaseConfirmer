using DiseaseConfirmer.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiseaseConfirmer.Data.Models
{
    public class CareerInfo : BaseDeletableModel<int>
    {
        public string Workplace { get; set; }

        public string Awards { get; set; }

        public string Degrees { get; set; }

        public string Experience { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string DoctorId { get; set; }

        public virtual ApplicationUser Doctor { get; set; }
    }
}
