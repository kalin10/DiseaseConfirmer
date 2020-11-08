namespace DiseaseConfirmer.Web.Areas.Administration.Controllers
{
    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
