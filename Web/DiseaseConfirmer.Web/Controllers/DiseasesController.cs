namespace DiseaseConfirmer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using DiseaseConfirmer.Web.ViewModels.Diseases;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DiseasesController : Controller
    {
        private readonly IDiseasesService diseasesService;
        private readonly ICategoriesService categoriesService;

        public DiseasesController(IDiseasesService diseasesService, ICategoriesService categoriesService)
        {
            this.diseasesService = diseasesService;
            this.categoriesService = categoriesService;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(DiseaseCreateInputModel input, string categoryName)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var categoryId = this.categoriesService.GetIdByName(categoryName);

            var diseasecategoryId = await this.diseasesService
                .CreateAsync(categoryId, input.Name, input.Symptoms, input.Cause, input.Тreatment, input.Description);

            return this.Redirect("/Categories/All");
        }

        public IActionResult ByName(string name)
        {
            string changedName = name.Replace('-', ' ');

            var viewModel = this.diseasesService.GetByName<DiseaseViewModel>(changedName);


            return this.View(viewModel);
        }
    }
}
