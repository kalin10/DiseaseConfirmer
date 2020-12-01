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

        public async Task DeleteAsync(int id)
        {
            Disease disease = await this.diseasesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);
            this.diseasesRepository.Delete(disease);
            await this.diseasesRepository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string name, string symptoms, string cause, string treatment, string description)
        {
            Disease disease = await this.diseasesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (disease != null)
            {
                disease.Name = name;
                disease.Symptoms = symptoms;
                disease.Cause = cause;
                disease.Тreatment = treatment;
                disease.Description = description;

                await this.diseasesRepository.SaveChangesAsync();
            }
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

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var disease = await this.diseasesRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();

            return disease;
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
