namespace DiseaseConfirmer.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("ById", "Inquiries", new { id = input.InquiryId });
            }

            var parentId =
                input.ParentId == 0 ?
                    (int?)null :
                    input.ParentId;

            if (parentId.HasValue)
            {
                if (!await this.commentsService.IsInPostId(parentId.Value, input.InquiryId))
                {
                    return this.BadRequest();
                }
            }

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            await this.commentsService.Create(input.InquiryId, userId, input.Content, parentId);
            return this.RedirectToAction("ById", "Inquiries", new { id = input.InquiryId });
        }
    }
}
