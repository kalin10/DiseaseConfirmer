namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;

    public interface ICategoriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<string>> GetCategoriesNames();

        Task<T> GetByNameAsync<T>(string name);

        Task<T> GetByIdAsync<T>(int id);

        Task<int> CreateAsync(string name, string description);

        Task EditAsync(int id, string name, string description);

        Task DeleteAsync(int id);

        Task<bool> DoesCategoryExist(string name);

        Task<Category> GetCategoryByName(string name);

        Task<Category> GetCategoryById(int id);
    }
}
