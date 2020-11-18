namespace DiseaseConfirmer.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInquiriesService
    {
        IEnumerable<T> GetAll<T>();

        T GetByHeading<T>(string heading);

        Task<int> CreateAsync(string heading, string symptoms, string detailedInformation, string userId);
    }
}
