using System.ComponentModel.DataAnnotations;

namespace DiseaseConfirmer.Web.ViewModels.Comments
{
    public class CreateCommentInputModel 
    {
        [Required]
        public int InquiryId { get; set; }

        public int ParentId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
