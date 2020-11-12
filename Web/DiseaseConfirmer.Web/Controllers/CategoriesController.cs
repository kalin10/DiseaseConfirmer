namespace DiseaseConfirmer.Web.Controllers
{
    using DiseaseConfirmer.Data;
    using DiseaseConfirmer.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult All()
        {
            var viewModel = new CategoriesViewModel();
            var categories = this.db.Categories.Select(x => new CategoryViewModel
            {
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            viewModel.Categories = categories;

            return this.View(viewModel);
        }
    }
}
