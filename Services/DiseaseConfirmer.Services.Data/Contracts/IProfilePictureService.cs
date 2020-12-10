namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IProfilePictureService
    {
        Task<int> CreateAsync(string url, string userId);
    }
}
