namespace DiseaseConfirmer.Web.Areas.Doctors.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : DoctorsController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var inquiryId = await this.commentsService.GetInquiryIdByCommentId(id);

            await this.commentsService.DeleteAsync(id);

            return this.Redirect($"/Inquiries/ById/{inquiryId}");
        }
    }
}
