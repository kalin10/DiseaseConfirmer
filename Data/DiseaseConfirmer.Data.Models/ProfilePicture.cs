namespace DiseaseConfirmer.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using DiseaseConfirmer.Data.Common.Models;

    public class ProfilePicture : BaseModel<int>
    {
        public string ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
