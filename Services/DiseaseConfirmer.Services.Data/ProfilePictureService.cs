namespace DiseaseConfirmer.Services.Data
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;

    public class ProfilePictureService : IProfilePictureService
    {
        private readonly IRepository<ProfilePicture> profilePicturesRepository;

        public ProfilePictureService(IRepository<ProfilePicture> profilePicturesRepository)
        {
            this.profilePicturesRepository = profilePicturesRepository;
        }

        public async Task<int> CreateAsync(string url, string userId)
        {
            var profilePicture = new ProfilePicture
            {
                ImageUrl = url,
                UserId = userId,
            };

            await this.profilePicturesRepository.AddAsync(profilePicture);
            await this.profilePicturesRepository.SaveChangesAsync();

            return profilePicture.Id;
        }
    }
}
