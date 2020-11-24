namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int inquiryId, string userId, string content, int? parentId = null);

        bool IsInPostId(int commentId, int inquiryId);
    }
}
