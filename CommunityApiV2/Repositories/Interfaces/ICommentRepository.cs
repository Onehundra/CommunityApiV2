using CommunityApiV2.Models;

namespace CommunityApiV2.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetByPostIdAsync(int postId);
        Task AddAsync(Comment comment);
    }
}
