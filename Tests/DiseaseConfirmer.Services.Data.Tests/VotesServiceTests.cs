namespace DiseaseConfirmer.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task TwoDownVotesShouldCountOnce()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));
            var service = new VotesService(repository);

            await service.VoteAsync(1, "1", false);
            await service.VoteAsync(1, "1", false);
            await service.VoteAsync(1, "1", false);

            await service.VoteAsync(1, "2", false);
            await service.VoteAsync(1, "2", false);
            await service.VoteAsync(1, "2", false);

            var votes = service.GetVotes(1);
            Assert.Equal(-2, votes);
        }

        [Fact]
        public async Task TwoUpVotesShouldCountOnce()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));
            var service = new VotesService(repository);

            await service.VoteAsync(1, "1", true);
            await service.VoteAsync(1, "1", true);
            await service.VoteAsync(1, "1", true);

            await service.VoteAsync(1, "2", true);
            await service.VoteAsync(1, "2", true);
            await service.VoteAsync(1, "2", true);

            var votes = service.GetVotes(1);
            Assert.Equal(2, votes);
        }

        [Fact]
        public async Task DifferentVotesFromUserShouldChanheVote()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var repository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));
            var service = new VotesService(repository);

            await service.VoteAsync(1, "1", true);
            await service.VoteAsync(1, "1", false);

            var votes = service.GetVotes(1);
            Assert.Equal(-1, votes);

            var votesInDiseaseForUser = await repository.All().CountAsync();
            Assert.Equal(1, votesInDiseaseForUser);
        }
    }
}
