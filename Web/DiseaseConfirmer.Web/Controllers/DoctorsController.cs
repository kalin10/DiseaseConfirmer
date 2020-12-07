namespace DiseaseConfirmer.Web.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Doctors;
    using Microsoft.AspNetCore.Mvc;

    public class DoctorsController : BaseController
    {
        private readonly IDoctorsService doctorsService;
        private readonly ICategoriesService categoriesService;

        public DoctorsController(IDoctorsService doctorsService, ICategoriesService categoriesService)
        {
            this.doctorsService = doctorsService;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> DoctorsInCategory(string categoryName)
        {
            var viewModel = new DoctorsViewModel();
            var doctors = await this.doctorsService.GetDoctorsByCategoryNameAsync<IndexDoctorViewModel>(categoryName);

            var categoriesNames = await this.categoriesService.GetCategoriesNames();

            viewModel.CategoryName = categoryName;
            viewModel.Doctors = doctors;
            viewModel.CategoiesNames = categoriesNames;

            return this.View(viewModel);
        }
    }
}
