namespace DiseaseConfirmer.Data.Models
{
    using DiseaseConfirmer.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public int InquiryId { get; set; }

        public virtual Inquiry Inquiry { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
