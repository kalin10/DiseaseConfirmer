namespace DiseaseConfirmer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<int> CreateAsync(string name, string description)
        {
            if (await this.categoriesRepository.All().FirstOrDefaultAsync(x => x.Name == name) == null)
            {
                var category = new Category
                {
                    Name = name,
                    Description = description,
                };

                await this.categoriesRepository.AddAsync(category);
                await this.categoriesRepository.SaveChangesAsync();

                return category.Id;
            }

            return -1;
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await this.categoriesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);
            this.categoriesRepository.Delete(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public async Task<bool> DoesCategoryExist(string name)
        {
            Category category = await this.categoriesRepository.All()
                .FirstOrDefaultAsync(x => x.Name == name);

            if (category == null)
            {
                return false;
            }

            return true;
        }

        public async Task EditAsync(int id, string name, string description)
        {
            Category category = await this.categoriesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                category.Name = name;
                category.Description = description;

                await this.categoriesRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            if (count.HasValue)
            {
                return await this.categoriesRepository
                    .All()
                    .OrderBy(x => x.Name)
                    .Take(count.Value)
                    .To<T>()
                    .ToListAsync();
            }
            else
            {
                return await this.categoriesRepository
                    .AllAsNoTracking()
                    .OrderBy(x => x.Name)
                    .To<T>()
                    .ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var category = await this.categoriesRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();

            return category;
        }

        public async Task<T> GetByNameAsync<T>(string name)
        {
            string changedName = name.Replace('-', ' ');

            var category = await this.categoriesRepository.All().Where(x => x.Name == changedName)
                .To<T>().FirstOrDefaultAsync();

            return category;
        }

        public async Task<IEnumerable<string>> GetCategoriesNames()
        {
            return await this.categoriesRepository
                .All()
                .Select(x => x.Name)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            Category category = await this.categoriesRepository
                .All()
                .FirstOrDefaultAsync(x => x.Name == name);

            return category;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            Category category = await this.categoriesRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            return category;
        }
    }
}
