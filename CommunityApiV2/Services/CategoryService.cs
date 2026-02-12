using CommunityApiV2.Models;
using CommunityApiV2.Repositories.Interfaces;
using CommunityApiV2.Services.Interfaces;

namespace CommunityApiV2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }
        public async Task CreateAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }
    }
}
