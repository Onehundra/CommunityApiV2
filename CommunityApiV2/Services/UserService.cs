using CommunityApiV2.Models;
using CommunityApiV2.Repositories.Interfaces;
using CommunityApiV2.Services.Interfaces;

namespace CommunityApiV2.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
      


        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<int?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null)
                return null;

            if (user.Password != password)
                return null;

            return user.Id;
        }

        public async Task<int> RegisterAsync(User user)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(user.Username);

            if (existingUser != null)
                return 0;

            await _userRepository.AddAsync(user);

            return user.Id;
        }

        public async Task<bool> UpdateAsync(int id, User updatedUser)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);

            if (existingUser == null)
                return false;

            existingUser.Username = updatedUser.Username;
            existingUser.Password = updatedUser.Password;
            existingUser.Email = updatedUser.Email;

            await _userRepository.UpdateAsync(existingUser);

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return false;

            await _userRepository.DeleteAsync(user);

            return true;
        }
    }
}
