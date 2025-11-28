using Blog.API.Models;
using Blog.API.Models.DTOs.User;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface IUserRepository
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task<int> UpdateUserAsync(int id, User user);
        Task<int> DeleteUserAsync(int id);
    }
}
