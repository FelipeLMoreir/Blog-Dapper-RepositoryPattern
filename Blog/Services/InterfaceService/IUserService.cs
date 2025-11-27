using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface IUserService
    {
        Task<List<UserResponseDTO>> GetAllUsersAsync();
        Task CreateUserAsync(UserRequestDTO dto);
        Task<bool> UpdateUserAsync(int id, UserRequestDTO dto);
        Task<bool> DeleteUserAsync(int id);
    }
}
