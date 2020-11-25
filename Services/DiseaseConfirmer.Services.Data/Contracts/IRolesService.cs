namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;

    public interface IRolesService
    {
        Task<ApplicationUser> AddUserToRoleAsync(string userId, string roleName);

        Task<ApplicationUser> RemoveUserFromRoleAsync(string userId, string roleName);
    }
}
