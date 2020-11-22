namespace DiseaseConfirmer.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Services.Mapping;

    public class InquiriesService : IInquiriesService
    {
        private readonly IDeletableEntityRepository<Inquiry> inquiriesRepository;

        public InquiriesService(IDeletableEntityRepository<Inquiry> inquiriesRepository)
        {
            this.inquiriesRepository = inquiriesRepository;
        }

        public async Task<int> CreateAsync(string heading, string symptoms, string detailedInformation, string userId)
        {
            var inquiry = new Inquiry
            {
                Heading = heading,
                Symptoms = symptoms,
                DetailedInformation = detailedInformation,
                UserId = userId,
            };

            await this.inquiriesRepository.AddAsync(inquiry);
            await this.inquiriesRepository.SaveChangesAsync();

            return inquiry.Id;
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 4, string userId = null)
        {
            IQueryable<Inquiry> query;
            if (!string.IsNullOrEmpty(userId))
            {
                query = this.inquiriesRepository.All()
                    .Where(x => x.UserId == userId)
                    .OrderBy(x => x.CreatedOn)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
            else
            {
                query = this.inquiriesRepository.All()
                    .OrderBy(x => x.CreatedOn)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var inquiry = this.inquiriesRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return inquiry;
        }

        public int GetCount(string userId = null)
        {
            IQueryable<Inquiry> query = this.inquiriesRepository.All();
            int count;
            if (userId != null)
            {
                count = query.Count(x => x.UserId == userId);
            }
            else
            {
                count = query.Count();
            }

            return count;
        }
    }
}
