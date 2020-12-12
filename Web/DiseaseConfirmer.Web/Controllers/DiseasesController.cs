namespace DiseaseConfirmer.Web.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Diseases;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DiseasesController : BaseController
    {
        private readonly IDiseasesService diseasesService;
        private readonly ICategoriesService categoriesService;

        public DiseasesController(IDiseasesService diseasesService, ICategoriesService categoriesService)
        {
            this.diseasesService = diseasesService;
            this.categoriesService = categoriesService;
        }

        [Authorize(Roles = "Doctor")]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Add(DiseaseCreateInputModel input, string categoryName)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var category = await this.categoriesService.GetCategoryByName(categoryName);
            var categoryId = category.Id;

            var diseaseId = await this.diseasesService
                .CreateAsync(categoryId, input.Name, input.Symptoms, input.Cause, input.Тreatment, input.Description);

            if (diseaseId == -1)
            {
                this.ModelState.AddModelError("Name", "Disease already exists");
                return this.View(input);
            }

            return this.Redirect("/Categories/All");
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.diseasesService.DeleteAsync(id);
            return this.Redirect("/Categories/All");
        }
    }
}
