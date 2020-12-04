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
        private readonly ICategoriesService categoriesService;

        public DoctorsService(
            IDeletableEntityRepository<ApplicationUser> doctorsRepository,
            ICategoriesService categoriesService)
        {
            this.doctorsRepository = doctorsRepository;
            this.categoriesService = categoriesService;
        }

        public async Task AddCareerInfoId(string doctorId, int careerInfoId)
        {
            var user = await this.doctorsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == doctorId);

            user.CareerInfoId = careerInfoId;
            await this.doctorsRepository.SaveChangesAsync();
        }

        public async Task<bool> ChangeCategoryAsync(string doctorId, string categoryName)
        {
            if (await this.categoriesService.DoesCategoryExist(categoryName))
            {
                var user = await this.doctorsRepository
                                .All()
                                .FirstOrDefaultAsync(x => x.Id == doctorId);

                Category category = await this.categoriesService.GetCategoryByName(categoryName);

                user.CategoryId = category.Id;
                user.Category = category;
                await this.doctorsRepository.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<string> GetCategoryNameByDoctorId(string doctorId)
        {
            ApplicationUser doctor = await this.doctorsRepository.All()
                .FirstOrDefaultAsync(x => x.Id == doctorId);

            var categoryId = doctor.CategoryId;

            string categoryName = await this.categoriesService.GetNameByIdAsync(categoryId.Value);

            return categoryName;
        }
    }
}
