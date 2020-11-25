namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;

    public interface IUsersService
    {
        Task<ApplicationUser> GetUserByIdAsync(string userId);
    }
}
