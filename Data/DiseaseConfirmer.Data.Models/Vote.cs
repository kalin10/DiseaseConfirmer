namespace DiseaseConfirmer.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Common.Models;
    using DiseaseConfirmer.Data.Models.Enums;

    public class Vote : BaseModel<int>
    {
        public int DiseaseId { get; set; }

        public virtual Disease Disease { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
