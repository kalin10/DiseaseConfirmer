namespace DiseaseConfirmer.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int inquiryId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                InquiryId = inquiryId,
                UserId = userId,
            };
            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Comment comment = await this.commentsRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.commentsRepository.Delete(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task<bool> IsInPostId(int commentId, int inquiryId)
        {
            var commentInquiryId = await this.commentsRepository.All().Where(x => x.Id == commentId)
                .Select(x => x.InquiryId).FirstOrDefaultAsync();

            return commentInquiryId == inquiryId;
        }
    }
}
