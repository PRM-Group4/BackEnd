using BOs.Models;
using Services.Modal.Request;
using Services.Modal.Response;

namespace Services.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<bool> UserExistsAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<UserResponse> GetUserProfile(int id);
    }
}

