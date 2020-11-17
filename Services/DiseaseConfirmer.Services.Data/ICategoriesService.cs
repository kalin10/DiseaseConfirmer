namespace DiseaseConfirmer.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);

        int GetIdByName(string name);

        Task<int> CreateAsync(string name, string description);
    }
}
