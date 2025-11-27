using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface IUserRoleService
    {
        Task<List<UserRoleResponseDTO>> GetRolesByUserAsync(int userId);
        Task<List<UserRoleResponseDTO>> GetUsersByRoleAsync(int roleId);
    }
}
