namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(int diseaseId, string userId, bool isUpVote);

        int GetVotes(int diseaseId);
    }
}
