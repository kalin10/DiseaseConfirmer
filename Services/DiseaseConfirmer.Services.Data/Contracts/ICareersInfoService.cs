namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICareersInfoService
    {
        Task<int> CreateAsync(string doctorId);

        Task EditAsync(int id, string name, string workplace, string awards, string degrees, string experience);
    }
}
