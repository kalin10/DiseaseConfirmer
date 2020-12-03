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

        public async Task ChangeAwardsAsync(string doctorId, string awards)
        {
            CareerInfo careerInfo = await this.careerInfoRepository.All()
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            careerInfo.Awards = awards;
            await this.careerInfoRepository.SaveChangesAsync();
        }

        public async Task ChangeDegreesAsync(string doctorId, string degrees)
        {
            CareerInfo careerInfo = await this.careerInfoRepository.All()
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            careerInfo.Degrees = degrees;
            await this.careerInfoRepository.SaveChangesAsync();
        }

        public async Task ChangeExperienceAsync(string doctorId, string experience)
        {
            CareerInfo careerInfo = await this.careerInfoRepository.All()
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            careerInfo.Experience = experience;
            await this.careerInfoRepository.SaveChangesAsync();
        }

        public async Task ChangeWorkplaceAsync(string doctorId, string workplace)
        {
            CareerInfo careerInfo = await this.careerInfoRepository.All()
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            careerInfo.Workplace = workplace;
            await this.careerInfoRepository.SaveChangesAsync();
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

        public async Task<string> GetAwardsAsync(string doctorId)
        {
            CareerInfo careerInfo = await this.careerInfoRepository.All()
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            return careerInfo.Awards;
        }

        public async Task<string> GetDegreesAsync(string doctorId)
        {
            CareerInfo careerInfo = await this.careerInfoRepository.All()
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            return careerInfo.Degrees;
        }

        public async Task<string> GetExperienceAsync(string doctorId)
        {
            CareerInfo careerInfo = await this.careerInfoRepository.All()
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            return careerInfo.Experience;
        }

        public async Task<string> GetWorkplaceAsync(string doctorId)
        {
            CareerInfo careerInfo = await this.careerInfoRepository.All()
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            return careerInfo.Workplace;
        }
    }
}
