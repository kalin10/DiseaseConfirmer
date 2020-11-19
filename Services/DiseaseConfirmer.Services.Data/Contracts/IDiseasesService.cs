namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDiseasesService
    {
        IEnumerable<T> GetAllByCategory<T>(string categoryName, int? count = null);

        T GetByName<T>(string name);

        Task<int> CreateAsync(int categoryId, string name, string symptoms, string cause, string treatment, string description);
    }
}
