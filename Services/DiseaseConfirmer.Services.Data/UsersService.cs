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

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<IEnumerable<T>> GetAllUsersAsync<T>()
        {
            return await this.usersRepository
                .All()
                .OrderBy(x => x.UserName)
                .To<T>()
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var user = await this.usersRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == userId);

            return user;
        }
    }
}
