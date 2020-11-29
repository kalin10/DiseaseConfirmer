namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDiseasesService
    {
        Task<IEnumerable<T>> GetAllByCategoryAsync<T>(string categoryName, int? count = null);

        Task<T> GetByNameAsync<T>(string name);

        Task<int> CreateAsync(int categoryId, string name, string symptoms, string cause, string treatment, string description);
    }
}
