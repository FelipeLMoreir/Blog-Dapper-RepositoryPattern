using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface IRoleRepository
    {
        Task<List<RoleResponseDTO>> GetAllRolesAsync();
        Task CreateRoleAsync(Role role);
        Task<int> UpdateRoleAsync(int id, Role role);
        Task<int> DeleteRoleAsync(int id);
    }
}
