namespace DiseaseConfirmer.Web.Areas.Doctors.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : DoctorsController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IDiseasesService diseasesService;

        public CategoriesController(ICategoriesService categoriesService, IDiseasesService diseasesService)
        {
            this.categoriesService = categoriesService;
            this.diseasesService = diseasesService;
        }

        [Authorize(Roles = "Doctor")]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
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
    }
}
