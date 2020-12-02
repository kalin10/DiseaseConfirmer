namespace DiseaseConfirmer.Services.Data
{
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class CareersInfoService : ICareersInfoService
    {
        private readonly IDeletableEntityRepository<CareerInfo> careerInfoRepository;

        public CareersInfoService(IDeletableEntityRepository<CareerInfo> careerInfoRepository)
        {
            this.careerInfoRepository = careerInfoRepository;
        }

        public async Task<int> CreateAsync(string doctorId)
        {
            if (await this.careerInfoRepository.All().FirstOrDefaultAsync(x => x.DoctorId == doctorId) == null)
            {
                var careerInfo = new CareerInfo
                {
                    DoctorId = doctorId,
                };

                await this.careerInfoRepository.AddAsync(careerInfo);
                await this.careerInfoRepository.SaveChangesAsync();

                return careerInfo.Id;
            }

            return -1;
        }

        public async Task EditAsync(int id, string name, string workplace, string awards, string degrees, string experience)
        {
            throw new System.NotImplementedException();
        }
    }
}
