﻿namespace DiseaseConfirmer.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class RolesController : AdministrationController
    {
        private readonly IRolesService rolesService;
        private readonly IUsersService usersService;

        public RolesController(IRolesService rolesService, IUsersService usersService)
        {
            this.rolesService = rolesService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> AddUserToRole(string userId, string roleName)
        {
            await this.rolesService.AddUserToRoleAsync(userId, roleName);

            return this.Redirect("/Administration/Users/All");
        }

        public async Task<IActionResult> RemoveUserFromRole(string userId, string roleName)
        {
            await this.rolesService.RemoveUserFromRoleAsync(userId, roleName);

            return this.Redirect("/Administration/Users/All");
        }
    }
}
