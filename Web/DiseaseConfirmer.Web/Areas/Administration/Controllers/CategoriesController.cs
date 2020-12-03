﻿namespace DiseaseConfirmer.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> All()
        {
            var model = new CategoriesViewModel
            {
                Categories = await this.categoriesService.GetAllAsync<IndexCategoryViewModel>(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.categoriesService.DeleteAsync(id);
            return this.Redirect("/Administration/Categories/All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.categoriesService.GetByIdAsync<EditCategoryInputModel>(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoriesService.EditAsync(input.Id, input.Name, input.Description);
            return this.Redirect("/Administration/Categories/All");
        }
    }
}
