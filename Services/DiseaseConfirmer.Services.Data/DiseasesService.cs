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

    public class DiseasesService : IDiseasesService
    {
        private readonly IDeletableEntityRepository<Disease> diseasesRepository;

        public DiseasesService(IDeletableEntityRepository<Disease> diseasesRepository)
        {
            this.diseasesRepository = diseasesRepository;
        }

        public async Task<int> CreateAsync(int categoryId, string name, string symptoms, string cause, string treatment, string description)
        {
            if (await this.diseasesRepository.All().FirstOrDefaultAsync(x => x.Name == name) == null)
            {
                var disease = new Disease
                {
                    Name = name,
                    Symptoms = symptoms,
                    Description = description,
                    Cause = cause,
                    CategoryId = categoryId,
                    Тreatment = treatment,
                };

                await this.diseasesRepository.AddAsync(disease);
                await this.diseasesRepository.SaveChangesAsync();

                return disease.Id;
            }

            return -1;
        }

        public async Task<IEnumerable<T>> GetAllByCategoryAsync<T>(string categoryName, int? count = null)
        {
            string changedName = categoryName.Replace('-', ' ');

            if (count.HasValue)
            {
                return await this.diseasesRepository.All()
                .Where(x => x.Category.Name == changedName)
                .OrderBy(x => x.Name)
                .Take(count.Value)
                .To<T>()
                .ToListAsync();
            }

            return await this.diseasesRepository.All()
                .Where(x => x.Category.Name == changedName)
                .OrderBy(x => x.Name)
                .To<T>()
                .ToListAsync();
        }

        public async Task<T> GetByNameAsync<T>(string name)
        {
            string changedName = name.Replace('-', ' ');

            var disease = await this.diseasesRepository.All()
                .Where(x => x.Name == changedName)
                .To<T>()
                .FirstOrDefaultAsync();

            return disease;
        }
    }
}
