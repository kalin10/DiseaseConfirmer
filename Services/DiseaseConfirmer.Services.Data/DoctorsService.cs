namespace DiseaseConfirmer.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DoctorsService : IDoctorsService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> doctorsRepository;

        public DoctorsService(IDeletableEntityRepository<ApplicationUser> doctorsRepository)
        {
            this.doctorsRepository = doctorsRepository;
        }

        public async Task AddCareerInfoId(string doctorId, int careerInfoId)
        {
            var user = await this.doctorsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == doctorId);

            user.CareerInfoId = careerInfoId;
            await this.doctorsRepository.SaveChangesAsync();
        }
    }
}
