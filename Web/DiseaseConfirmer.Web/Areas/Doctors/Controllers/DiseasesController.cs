namespace DiseaseConfirmer.Web.Areas.Doctors.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.Controllers;
    using DiseaseConfirmer.Web.ViewModels.Diseases;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.DoctorRoleName)]
    [Area("Doctors")]
    public class DiseasesController : BaseController
    {
        private readonly IDiseasesService diseasesService;

        public DiseasesController(IDiseasesService diseasesService)
        {
            this.diseasesService = diseasesService;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.diseasesService.GetByIdAsync<EditDiseaseInputModel>(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDiseaseInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.diseasesService.EditAsync(input.Id, input.Name, input.Symptoms, input.Cause, input.Тreatment, input.Description);
            return this.Redirect("/Categories/All");
        }
    }
}
