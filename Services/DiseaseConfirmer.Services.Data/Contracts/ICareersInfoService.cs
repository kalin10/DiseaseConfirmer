namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICareersInfoService
    {
        Task<int> CreateAsync(string doctorId);

        Task<string> GetWorkplaceAsync(string doctorId);

        Task<string> GetAwardsAsync(string doctorId);

        Task<string> GetDegreesAsync(string doctorId);

        Task<string> GetExperienceAsync(string doctorId);

        Task ChangeWorkplaceAsync(string doctorId, string workplace);

        Task ChangeAwardsAsync(string doctorId, string awards);

        Task ChangeDegreesAsync(string doctorId, string degrees);

        Task ChangeExperienceAsync(string doctorId, string experience);
    }
}
