namespace DiseaseConfirmer.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class RolesController : AdministrationController
    {
        private readonly IRolesService rolesService;
        private readonly IUsersService usersService;
        private readonly IDoctorsService doctorsService;
        private readonly ICareersInfoService careersInfoService;

        public RolesController(
            IRolesService rolesService,
            IUsersService usersService,
            IDoctorsService doctorsService,
            ICareersInfoService careersInfoService)
        {
            this.rolesService = rolesService;
            this.usersService = usersService;
            this.doctorsService = doctorsService;
            this.careersInfoService = careersInfoService;
        }

        public async Task<IActionResult> AddUserToRole(string userId, string roleName)
        {
            await this.rolesService.AddUserToRoleAsync(userId, roleName);

            var user = await this.usersService.GetUserByIdAsync(userId);

            if (user.CareerInfoId == null)
            {
                int careerInfoId = await this.careersInfoService.CreateAsync(userId);
                if (careerInfoId != -1)
                {
                    await this.doctorsService.AddCareerInfoId(userId, careerInfoId);
                }
            }

            return this.Redirect("/Administration/Users/All");
        }

        public async Task<IActionResult> RemoveUserFromRole(string userId, string roleName)
        {
            await this.rolesService.RemoveUserFromRoleAsync(userId, roleName);

            return this.Redirect("/Administration/Users/All");
        }
    }
}
