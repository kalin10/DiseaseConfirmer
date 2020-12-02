using System.Threading.Tasks;

namespace DiseaseConfirmer.Services.Data.Contracts
{
    public interface IDoctorsService
    {
        Task AddCareerInfoId(string doctorId, int careerInfoId);
    }
}
