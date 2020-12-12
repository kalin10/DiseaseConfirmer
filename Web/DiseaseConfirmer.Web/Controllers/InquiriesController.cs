namespace DiseaseConfirmer.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Inquiries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class InquiriesController : BaseController
    {
        private const int ItemsPerPage = 5;

        private readonly IInquiriesService inquiriesService;

        public InquiriesController(IInquiriesService inquiriesService)
        {
            this.inquiriesService = inquiriesService;
        }

        public async Task<IActionResult> All(int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new InquiriesViewModel
            {
                ItemsPerPage = ItemsPerPage,
                CurrentPage = page,
                InquiriesCount = await this.inquiriesService.GetCountAsync(),
                Inqueries = await this.inquiriesService.GetAllAsync<IndexInquiryViewModel>(page, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> AllById(int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var viewModel = new InquiriesViewModel
            {
                ItemsPerPage = ItemsPerPage,
                CurrentPage = page,
                InquiriesCount = await this.inquiriesService.GetCountAsync(userId),
                Inqueries = await this.inquiriesService.GetAllAsync<IndexInquiryViewModel>(page, ItemsPerPage, userId),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(InquiriesCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            await this.inquiriesService.CreateAsync(input.Heading, input.Symptoms, input.DetailedInformation, userId);

            return this.Redirect("/Inquiries/AllById");
        }

        public async Task<IActionResult> ById(int id)
        {
            var viewModel = await this.inquiriesService.GetByIdAsync<InquiryViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = this.User;
            var userName = user.Identity.Name;

            var inquiry = await this.inquiriesService.GetByIdAsync<InquiryViewModel>(id);

            if (inquiry == null)
            {
                return this.NotFound();
            }

            if (userName == inquiry.UserUserName || user.IsInRole(GlobalConstants.DoctorRoleName))
            {
                await this.inquiriesService.DeleteAsync(id);
            }
            else
            {
                return this.Unauthorized();
            }

            if (user.IsInRole(GlobalConstants.DoctorRoleName))
            {
                return this.Redirect("/Inquiries/All");
            }
            else
            {
                return this.Redirect("/Inquiries/AllById");
            }
        }
    }
}
