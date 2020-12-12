namespace DiseaseConfirmer.Web.Areas.Doctors.Controllers
{
    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.DoctorRoleName)]
    [Area("Doctors")]
    public class DoctorsController : BaseController
    {
    }
}
