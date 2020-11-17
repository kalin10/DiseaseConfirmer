namespace DiseaseConfirmer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data;
    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data;
    using DiseaseConfirmer.Services.Mapping;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IDiseasesService diseasesService;

        public CategoriesController(ICategoriesService categoriesService, IDiseasesService diseasesService)
        {
            this.categoriesService = categoriesService;
            this.diseasesService = diseasesService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryCreateInputModel input)
        {
            var categoryId = await this.categoriesService.CreateAsync(input.Name, input.Description);

            return this.Redirect("/Categories/All");
        }

        public IActionResult All()
        {
            var viewModel = new CategoriesViewModel();
            var categories = this.categoriesService.GetAll<IndexCategoryViewModel>()
                .ToList();

            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        public IActionResult ByName(string name)
        {
            string changedName = name.Replace('-', ' ');

            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(changedName);
            var diseases = this.diseasesService.GetAllByCategory<DiseaseInCategoryViewModel>(changedName)
                .ToList();

            viewModel.Diseases = diseases;

            return this.View(viewModel);
        }
    }
}
