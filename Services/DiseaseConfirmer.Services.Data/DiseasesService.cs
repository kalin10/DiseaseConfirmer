namespace DiseaseConfirmer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Mapping;

    public class DiseasesService : IDiseasesService
    {
        private readonly IDeletableEntityRepository<Disease> diseasesRepository;

        public DiseasesService(IDeletableEntityRepository<Disease> diseasesRepository)
        {
            this.diseasesRepository = diseasesRepository;
        }

        public IEnumerable<T> GetAllByCategory<T>(string categoryName, int? count = null)
        {
            IQueryable<Disease> query = this.diseasesRepository.All()
                .Where(x => x.Category.Name == categoryName)
                .OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var disease = this.diseasesRepository.All().Where(x => x.Name == name)
                .To<T>().FirstOrDefault();

            return disease;
        }
    }
}
