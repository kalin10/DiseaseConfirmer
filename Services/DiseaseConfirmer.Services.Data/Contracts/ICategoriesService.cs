namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<T> GetByNameAsync<T>(string name);

        Task<int> GetIdByNameAsync(string name);

        Task<int> CreateAsync(string name, string description);
    }
}
