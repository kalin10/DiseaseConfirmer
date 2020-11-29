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

        public async Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage = 4, string userId = null)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await this.inquiriesRepository.All()
                    .Where(x => x.UserId == userId)
                    .OrderBy(x => x.CreatedOn)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync();
            }
            else
            {
                return await this.inquiriesRepository.All()
                    .OrderBy(x => x.CreatedOn)
                    .Skip((page - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .To<T>()
                    .ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var inquiry = await this.inquiriesRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

            return inquiry;
        }

        public async Task<int> GetCountAsync(string userId = null)
        {
            if (userId != null)
            {
                return await this.inquiriesRepository.All().CountAsync(x => x.UserId == userId);
            }
            else
            {
                return await this.inquiriesRepository.All().CountAsync();
            }
        }
    }
}
