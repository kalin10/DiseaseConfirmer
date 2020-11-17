namespace DiseaseConfirmer.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using DiseaseConfirmer.Web.ViewModels.Diseases;
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

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DiseaseCreateInputModel input, string categoryName)
        {
            string changedName = categoryName.Replace('-', ' ');

            var categoryId = this.categoriesService.GetIdByName(changedName);

            var diseasecategoryId = await this.diseasesService
                .CreateAsync(categoryId, input.Name, input.Symptoms, input.Cause, input.Тreatment, input.Description);
            //int categoryId, string name, string symptoms, string cause, string treatment, string description

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
