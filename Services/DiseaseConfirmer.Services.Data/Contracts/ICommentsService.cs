namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int inquiryId, string userId, string content, int? parentId = null);

        Task<bool> IsInPostId(int commentId, int inquiryId);

        Task DeleteAsync(int id);
    }
}
