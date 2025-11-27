using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface IUserRoleRepository
    {
        Task<List<UserRoleResponseDTO>> GetRolesByUserAsync(int userId);
        Task<List<UserRoleResponseDTO>> GetUsersByRoleAsync(int roleId);
    }
}
