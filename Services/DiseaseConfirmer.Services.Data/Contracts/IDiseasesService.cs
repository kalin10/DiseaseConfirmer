namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDiseasesService
    {
        Task<IEnumerable<T>> GetAllByCategoryAsync<T>(string categoryName, int? count = null);

        Task<T> GetByIdAsync<T>(int id);

        Task<int> CreateAsync(int categoryId, string name, string symptoms, string cause, string treatment, string description);

        Task EditAsync(int id, string name, string symptoms, string cause, string treatment, string description);

        Task DeleteAsync(int id);
    }
}
