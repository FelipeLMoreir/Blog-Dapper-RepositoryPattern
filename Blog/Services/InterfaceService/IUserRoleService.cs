using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface IUserRoleService
    {
        Task AddUserRoleAsync(UserRoleRequestDTO dto);
        Task RemoveUserRoleAsync(UserRoleRequestDTO dto);
        Task<List<UserRoleResponseDTO>> GetRolesByUserAsync(int userId);
        Task<List<UserRoleResponseDTO>> GetUsersByRoleAsync(int roleId);
    }
}
