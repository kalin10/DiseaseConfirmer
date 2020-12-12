namespace DiseaseConfirmer.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Web.ViewModels.Administration.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


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

        public async Task<IActionResult> Delete(string userId)
        {
            await this.usersService.DeleteUserAsync(userId);
            return this.Redirect("/Administration/Users/All");
        }
    }
}
