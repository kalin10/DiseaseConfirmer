namespace DiseaseConfirmer.Web.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using DiseaseConfirmer.Web.ViewModels.Diseases;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IDiseasesService diseasesService;

        public CategoriesController(ICategoriesService categoriesService, IDiseasesService diseasesService)
        {
            this.categoriesService = categoriesService;
            this.diseasesService = diseasesService;
        }

        public async Task<IActionResult> All()
        {
            var viewModel = new CategoriesViewModel();
            var categories = await this.categoriesService.GetAllAsync<IndexCategoryViewModel>();

            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        public async Task<IActionResult> ByName(string name)
        {
            var viewModel = await this.categoriesService.GetByNameAsync<CategoryViewModel>(name);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            var diseases = await this.diseasesService.GetAllByCategoryAsync<DiseaseViewModel>(name);

            viewModel.Diseases = diseases;

            return this.View(viewModel);
        }
    }
}
