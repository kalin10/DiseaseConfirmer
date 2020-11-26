namespace DiseaseConfirmer.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class DashboardController : AdministrationController
    {
        public DashboardController()
        {

        }

        public async Task<IActionResult> Index()
        {
            return this.View();
        }
    }
}
