namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDoctorsService
    {
        Task AddCareerInfoId(string doctorId, int careerInfoId);

        Task<string> GetCategoryNameByDoctorId(string doctorId);

        Task<IEnumerable<T>> GetDoctorsByCategoryNameAsync<T>(string categoryName);

        Task<bool> ChangeCategoryAsync(string doctorId, string categoryName);
    }
}
