namespace DiseaseConfirmer.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Data.Models.Enums;
    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public int GetVotes(int diseaseId)
        {
            return this.votesRepository
                .All()
                .Where(x => x.DiseaseId == diseaseId)
                .Sum(x => (int)x.Type);
        }

        public async Task VoteAsync(int diseaseId, string userId, bool isUpVote)
        {
            Vote vote = await this.votesRepository
                .All()
                .FirstOrDefaultAsync(x => x.DiseaseId == diseaseId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    DiseaseId = diseaseId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
