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

    public class ComplaintsService : IComplaintsService
    {
        private readonly IDeletableEntityRepository<Complaint> complaintsRepository;

        public ComplaintsService(IDeletableEntityRepository<Complaint> complaintsRepository)
        {
            this.complaintsRepository = complaintsRepository;
        }

        public async Task CreateAsync(string userId, string content)
        {
            var complaint = new Complaint
            {
                Content = content,
                UserId = userId,
            };

            await this.complaintsRepository.AddAsync(complaint);
            await this.complaintsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            return await this.complaintsRepository
                    .All()
                    .OrderByDescending(x => x.CreatedOn)
                    .To<T>()
                    .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Complaint complaint = await this.complaintsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.complaintsRepository.Delete(complaint);
            await this.complaintsRepository.SaveChangesAsync();
        }
    }
}
