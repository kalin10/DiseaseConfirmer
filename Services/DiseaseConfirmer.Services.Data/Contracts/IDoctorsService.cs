namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IDoctorsService
    {
        Task AddCareerInfoId(string doctorId, int careerInfoId);

        Task<string> GetCategoryNameByDoctorId(string doctorId);

        Task<bool> ChangeCategoryAsync(string doctorId, string categoryName);
    }
}
