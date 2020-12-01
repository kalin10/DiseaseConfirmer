namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<T> GetByNameAsync<T>(string name);

        Task<T> GetByIdAsync<T>(int id);

        Task<int> GetIdByNameAsync(string name);

        Task<int> CreateAsync(string name, string description);

        Task EditAsync(int id, string name, string description);

        Task DeleteAsync(int id);
    }
}
