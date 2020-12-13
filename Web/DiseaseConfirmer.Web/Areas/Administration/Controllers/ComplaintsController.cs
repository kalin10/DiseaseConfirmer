using DiseaseConfirmer.Services.Data.Contracts;
using DiseaseConfirmer.Web.ViewModels.Complaints;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DiseaseConfirmer.Web.Areas.Administration.Controllers
{
    public class ComplaintsController : AdministrationController
    {
        private readonly IComplaintsService complaintsService;

        public ComplaintsController(IComplaintsService complaintsService)
        {
            this.complaintsService = complaintsService;
        }

        public async Task<IActionResult> All()
        {
            var model = new ComplaintsViewModel
            {
                Complaints = await this.complaintsService.GetAllAsync<IndexComplaintViewModel>(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.complaintsService.DeleteAsync(id);
            return this.Redirect("/Administration/Complaints/All");
        }
    }
}
