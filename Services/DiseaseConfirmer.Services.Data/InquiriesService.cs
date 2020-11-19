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

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<Inquiry> query =
                this.inquiriesRepository.All()
                                        .OrderBy(x => x.CreatedOn);

            return query.To<T>().ToList();
        }

        public T GetByHeading<T>(string heading)
        {
            string changedHeading = heading.Replace('-', ' ');

            var inquiry = this.inquiriesRepository.All().Where(x => x.Heading == changedHeading)
                .To<T>().FirstOrDefault();

            return inquiry;
        }
    }
}
