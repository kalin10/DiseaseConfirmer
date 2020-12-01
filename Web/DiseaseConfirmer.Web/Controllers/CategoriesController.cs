namespace DiseaseConfirmer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data;
    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Services.Mapping;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IDiseasesService diseasesService;

        public CategoriesController(ICategoriesService categoriesService, IDiseasesService diseasesService)
        {
            this.categoriesService = categoriesService;
            this.diseasesService = diseasesService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CategoryCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var categoryId = await this.categoriesService.CreateAsync(input.Name, input.Description);

            if (categoryId == -1)
            {
                this.ModelState.AddModelError("Name", "Category already exists");
                return this.View(input);
            }

            return this.Redirect("/Categories/All");
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

            var diseases = await this.diseasesService.GetAllByCategoryAsync<DiseaseInCategoryViewModel>(name);

            viewModel.Diseases = diseases;

            return this.View(viewModel);
        }
    }
}
