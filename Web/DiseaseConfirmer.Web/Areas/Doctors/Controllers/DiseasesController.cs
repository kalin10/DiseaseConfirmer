namespace DiseaseConfirmer.Web.Areas.Doctors.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Diseases;
    using Microsoft.AspNetCore.Mvc;

    public class DiseasesController : DoctorsController
    {
        private readonly IDiseasesService diseasesService;

        public DiseasesController(IDiseasesService diseasesService)
        {
            this.diseasesService = diseasesService;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.diseasesService.GetByIdAsync<EditDiseaseInputModel>(id);

            if (model == null)
            {
                return this.NotFound();
            }

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
