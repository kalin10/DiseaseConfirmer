namespace DiseaseConfirmer.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Inquiries;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class InquiriesController : Controller
    {
        private readonly IInquiriesService inquiriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public InquiriesController(IInquiriesService inquiriesService, UserManager<ApplicationUser> userManager)
        {
            this.inquiriesService = inquiriesService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var viewModel = new InquiriesViewModel();
            var inqueries = this.inquiriesService.GetAll<IndexInquiryViewModel>();

            viewModel.Inqueries = inqueries;

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> ById()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var userId = user.Id;

            var viewModel = new InquiriesViewModel();
            var inqueries = this.inquiriesService.GetAll<IndexInquiryViewModel>(userId);

            viewModel.Inqueries = inqueries;

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

            return this.Redirect("/Inquiries/All");
        }

        public IActionResult ByHeading(string name)
        {
            var viewModel = this.inquiriesService.GetByHeading<InquiryViewModel>(name);

            return this.View(viewModel);
        }
    }
}
