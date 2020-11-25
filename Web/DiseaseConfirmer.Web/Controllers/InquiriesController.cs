namespace DiseaseConfirmer.Web.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Inquiries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class InquiriesController : BaseController
    {
        private const int ItemsPerPage = 4;

        private readonly IInquiriesService inquiriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public InquiriesController(IInquiriesService inquiriesService, UserManager<ApplicationUser> userManager)
        {
            this.inquiriesService = inquiriesService;
            this.userManager = userManager;
        }

        public IActionResult All(int page = 1)
        {
            if (page <= 0)
            {
                return this.NotFound();
            }

            var viewModel = new InquiriesViewModel
            {
                ItemsPerPage = ItemsPerPage,
                CurrentPage = page,
                InquiriesCount = this.inquiriesService.GetCount(),
                Inqueries = this.inquiriesService.GetAll<IndexInquiryViewModel>(page,ItemsPerPage),
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

            var user = await this.userManager.GetUserAsync(this.User);

            var userId = user.Id;

            var viewModel = new InquiriesViewModel
            {
                ItemsPerPage = ItemsPerPage,
                CurrentPage = page,
                InquiriesCount = this.inquiriesService.GetCount(userId),
                Inqueries = this.inquiriesService.GetAll<IndexInquiryViewModel>(page, ItemsPerPage, userId),
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
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = user.Id;

            var inquiryId =
                await this.inquiriesService.CreateAsync(input.Heading, input.Symptoms, input.DetailedInformation, userId);

            return this.Redirect("/Inquiries/AllById");
        }

        public IActionResult ById(int id)
        {
            var viewModel = this.inquiriesService.GetById<InquiryViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
