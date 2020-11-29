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
            var category = new Category
            {
                Name = name,
                Description = description,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Id;
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
                    .All()
                    .OrderBy(x => x.Name)
                    .To<T>()
                    .ToListAsync();
            }
        }

        public async Task<T> GetByNameAsync<T>(string name)
        {
            string changedName = name.Replace('-', ' ');

            var category = await this.categoriesRepository.All().Where(x => x.Name == changedName)
                .To<T>().FirstOrDefaultAsync();

            return category;
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
            var category = await this.categoriesRepository
                .All()
                .FirstOrDefaultAsync(x => x.Name == name);

            return category.Id;
        }
    }
}
