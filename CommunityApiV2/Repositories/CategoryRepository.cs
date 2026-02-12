using CommunityApiV2.Data;
using CommunityApiV2.Models;
using CommunityApiV2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommunityApiV2.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CommunityDbContext _db;

        public CategoryRepository (CommunityDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task AddAsync(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }


        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }
    }
}
