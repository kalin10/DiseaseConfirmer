namespace DiseaseConfirmer.Services.Data.Tests
{
    using System;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Data.Repositories;
    using DiseaseConfirmer.Services.Mapping;
    using DiseaseConfirmer.Web.ViewModels.Complaints;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ComplaintsServiceTests
    {
        [Fact]
        public async Task CreateAsyncWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var db = new ApplicationDbContext(options.Options);
            var repository = new EfDeletableEntityRepository<Complaint>(db);
            var service = new ComplaintsService(repository);

            var result = await service.CreateAsync("1", "first complaint");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteAsyncWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var db = new ApplicationDbContext(options.Options);
            var repository = new EfDeletableEntityRepository<Complaint>(db);
            var service = new ComplaintsService(repository);

            var result = await service.CreateAsync("1", "first complaint");
            await service.DeleteAsync(result.Id);

            var actualComplaintsCount = await repository.All().CountAsync();

            Assert.Equal(0, actualComplaintsCount);
        }

        [Fact]
        public async Task DeleteAsyncThrowsException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var db = new ApplicationDbContext(options.Options);
            var repository = new EfDeletableEntityRepository<Complaint>(db);
            var service = new ComplaintsService(repository);

            var result = await service.CreateAsync("1", "first complaint");
            await service.DeleteAsync(result.Id);

            await Assert.ThrowsAnyAsync<Exception>(async () => await service.DeleteAsync(result.Id));
        }

        [Fact]
        public async Task GetAllAsyncWorksCorrectly()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var db = new ApplicationDbContext(options.Options);
            var repository = new EfDeletableEntityRepository<Complaint>(db);
            var service = new ComplaintsService(repository);
            AutoMapperConfig.RegisterMappings(typeof(TestComplaintModel).Assembly);

            await service.CreateAsync("1", "first complaint");
            await service.CreateAsync("1", "second complaint");

            var result = await service.GetAllAsync<TestComplaintModel>();

            Assert.NotNull(result);
        }

        public class TestComplaintModel : IMapFrom<Complaint>
        {
            public int Id { get; set; }

            public string Content { get; set; }
        }
    }
}
