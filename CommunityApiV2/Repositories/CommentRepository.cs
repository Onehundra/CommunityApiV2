using CommunityApiV2.Data;
using CommunityApiV2.Models;
using CommunityApiV2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommunityApiV2.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CommunityDbContext _db;

        public CommentRepository(CommunityDbContext db)
        {
            _db = db;
        }

        public async Task<List<Comment>> GetByPostIdAsync(int postId)
        {
            return await _db.Comments.Where(c => c.BlogPostId == postId).ToListAsync();
        }

        public async Task AddAsync(Comment comment)
        {
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();
        }
    }
}
