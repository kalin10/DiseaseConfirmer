namespace DiseaseConfirmer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IRepository<ProfilePicture> profilePictureRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IRepository<ProfilePicture> profilePictureRepository)
        {
            this.usersRepository = usersRepository;
            this.profilePictureRepository = profilePictureRepository;
        }

        public async Task ChangeProfilePictureAsync(string userId, int pictureId)
        {
            var user = await this.usersRepository.All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            var profilePicture = await this.profilePictureRepository.All()
                .FirstOrDefaultAsync(x => x.Id == pictureId);

            user.ProfilePictureId = pictureId;
            user.ProfilePicture = profilePicture;

            await this.usersRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllUsersAsync<T>()
        {
            return await this.usersRepository
                .All()
                .OrderBy(x => x.UserName)
                .To<T>()
                .ToListAsync();
        }

        public async Task<string> GetFirstNameByIdAsync(string userId)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            return user.FirstName;
        }

        public async Task<string> GetLastNameByIdAsync(string userId)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            return user.LastName;
        }

        public async Task<string> GetProfilePictureUrlAsync(string userId)
        {
            var user = await this.usersRepository.All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user.ProfilePictureId.HasValue)
            {
                var profilePicture = await this.profilePictureRepository.All()
                    .FirstOrDefaultAsync(x => x.Id == user.ProfilePictureId.Value);
                return profilePicture.ImageUrl;
            }

            return string.Empty;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            return user;
        }
    }
}
