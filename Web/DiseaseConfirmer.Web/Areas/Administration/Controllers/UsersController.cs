namespace DiseaseConfirmer.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Administration.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class UsersController : AdministrationController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public async Task<IActionResult> All()
        {
            var model = new AllUsersViewModel
            {
                Users = await this.usersService.GetAllUsersAsync<UserInListViewModel>(),
            };

            return this.View(model);
        }
    }
}
