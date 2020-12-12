namespace DiseaseConfirmer.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using DiseaseConfirmer.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public int? ParentId { get; set; }

        public virtual Comment Parent { get; set; }


        public int InquiryId { get; set; }

        public virtual Inquiry Inquiry { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
