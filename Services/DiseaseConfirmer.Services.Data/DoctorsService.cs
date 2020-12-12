namespace DiseaseConfirmer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Common;
    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class DoctorsService : IDoctorsService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> doctorsRepository;
        private readonly ICategoriesService categoriesService;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly string doctorRoleId;

        public DoctorsService(
            IDeletableEntityRepository<ApplicationUser> doctorsRepository,
            ICategoriesService categoriesService,
            RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
            this.doctorsRepository = doctorsRepository;
            this.categoriesService = categoriesService;
            this.doctorRoleId = this.roleManager
                .Roles
                .First(x => x.Name.ToLower() == GlobalConstants.DoctorRoleName.ToLower())
                .Id;
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
            ApplicationUser doctor = await this.doctorsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == doctorId);

            var categoryId = doctor.CategoryId;

            var category = await this.categoriesService.GetCategoryById(categoryId.Value);

            return category.Name;
        }

        public async Task<IEnumerable<T>> GetDoctorsByCategoryNameAsync<T>(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                return await this.doctorsRepository
                    .All()
                    .Where(d => d.Roles.Any(z => z.RoleId == this.doctorRoleId) && d.CategoryId != null)
                    .OrderBy(d => d.FirstName)
                    .ThenBy(d => d.LastName)
                    .To<T>()
                    .ToListAsync();
            }
            else
            {
                return await this.doctorsRepository
                    .All()
                    .Where(d => d.Roles.Any(z => z.RoleId == this.doctorRoleId) && d.Category.Name == categoryName)
                    .OrderBy(d => d.FirstName)
                    .ThenBy(d => d.LastName)
                    .To<T>()
                    .ToListAsync();
            }
        }
    }
}
