namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;

    public interface IComplaintsService
    {
        Task<Complaint> CreateAsync(string userId, string content);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task DeleteAsync(int id);
    }
}
