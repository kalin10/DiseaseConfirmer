namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInquiriesService
    {
        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 4, string userId = null);

        T GetById<T>(int id);

        Task<int> CreateAsync(string heading, string symptoms, string detailedInformation, string userId);

        int GetCount(string userId = null);
    }
}
