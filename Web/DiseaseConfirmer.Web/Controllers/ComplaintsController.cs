namespace DiseaseConfirmer.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Complaints;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ComplaintsController : BaseController
    {
        private readonly IComplaintsService complaintsService;

        public ComplaintsController(IComplaintsService complaintsService)
        {
            this.complaintsService = complaintsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(ComplaintInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Home/Index");
            }

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            await this.complaintsService.CreateAsync(userId, input.Content);

            return this.Redirect("/Home/Index");
        }
    }
}
