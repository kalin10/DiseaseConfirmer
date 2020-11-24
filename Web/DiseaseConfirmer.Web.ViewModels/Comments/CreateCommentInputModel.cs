namespace DiseaseConfirmer.Web.ViewModels.Comments
{
    public class CreateCommentInputModel 
    {
        public int InquiryId { get; set; }

        public int ParentId { get; set; }

        public string Content { get; set; }
    }
}
