namespace DiseaseConfirmer.Web.Areas.Doctors.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.DoctorRoleName)]
    [Area("Doctors")]
    public class CommentsController : BaseController
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
