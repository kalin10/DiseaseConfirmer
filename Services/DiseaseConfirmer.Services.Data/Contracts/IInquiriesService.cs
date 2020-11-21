namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInquiriesService
    {
        IEnumerable<T> GetAll<T>(string userId = null);

        T GetById<T>(int id);

        Task<int> CreateAsync(string heading, string symptoms, string detailedInformation, string userId);
    }
}
