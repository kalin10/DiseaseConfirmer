namespace DiseaseConfirmer.Services.Data
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.AspNetCore.Identity;

    public class RolesService : IRolesService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsersService usersService;

        public RolesService(
            UserManager<ApplicationUser> userManager,
            IUsersService usersService)
        {
            this.userManager = userManager;
            this.usersService = usersService;
        }

        public async Task<ApplicationUser> AddUserToRoleAsync(string userId, string roleName)
        {
            var user = await this.usersService.GetUserByIdAsync(userId);

            await this.userManager.AddToRoleAsync(user, roleName);

            return user;
        }

        public async Task<ApplicationUser> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            var user = await this.usersService.GetUserByIdAsync(userId);

            await this.userManager.RemoveFromRoleAsync(user, roleName);

            return user;
        }
    }
}
