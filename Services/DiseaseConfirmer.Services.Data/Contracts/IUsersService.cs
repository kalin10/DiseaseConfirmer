namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;

    public interface IUsersService
    {
        Task<ApplicationUser> GetUserByIdAsync(string userId);

        Task<string> GetFirstNameByIdAsync(string userId);

        Task<string> GetLastNameByIdAsync(string userId);

        Task<IEnumerable<T>> GetAllUsersAsync<T>();

        Task<string> GetProfilePictureUrlAsync(string userId);

        Task ChangeProfilePictureAsync(string userId, int pictureId);
    }
}
