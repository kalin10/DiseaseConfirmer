namespace DiseaseConfirmer.Web.Controllers
{
    using System.Linq;

    using DiseaseConfirmer.Services.Data;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class DiseaseController : Controller
    {
        private readonly IDiseasesService diseasesService;

        public DiseaseController(IDiseasesService diseasesService)
        {
            this.diseasesService = diseasesService;
        }

        //public IActionResult All()
        //{
        //    var viewModel = new CategoryViewModel();
        //    var diseases = this.diseasesService.GetAll<DiseaseInCategoryViewModel>()
        //        .ToList();

        //    viewModel.Diseases = diseases;

        //    return this.View(viewModel);
        //}

        //public IActionResult ByName(string name)
        //{
        //    var viewModel = this.diseasesService.GetByName<DiseaseViewModel>(name);

        //    return this.View(viewModel);
        //}
    }
}
