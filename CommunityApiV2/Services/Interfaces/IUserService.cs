using CommunityApiV2.Models;

namespace CommunityApiV2.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<int?> LoginAsync(string username, string password);
        Task<int> RegisterAsync(User user);
        Task<bool> UpdateAsync(int id, User updatedUser);
        Task<bool> DeleteAsync(int id);


    }
}
