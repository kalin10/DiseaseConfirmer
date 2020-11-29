namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInquiriesService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage = 4, string userId = null);

        Task<T> GetByIdAsync<T>(int id);

        Task<int> CreateAsync(string heading, string symptoms, string detailedInformation, string userId);

        Task<int> GetCountAsync(string userId = null);
    }
}
