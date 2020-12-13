namespace DiseaseConfirmer.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Common.Models;

    public class Complaint : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
