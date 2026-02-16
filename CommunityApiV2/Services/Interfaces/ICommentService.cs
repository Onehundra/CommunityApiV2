using CommunityApiV2.Models;

namespace CommunityApiV2.Services.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetByPostIdAsync(int postId);
        Task<string> CreateAsync(Comment comment);
    }
}
