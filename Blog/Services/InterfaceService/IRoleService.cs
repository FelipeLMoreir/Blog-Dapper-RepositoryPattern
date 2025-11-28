using Blog.API.Models.DTOs.Role;

namespace Blog.API.Services.InterfaceService
{
    public interface IRoleService
    {
        Task<List<RoleResponseDTO>> GetAllRolesAsync();
        Task CreateRoleAsync(RoleRequestDTO role);
        Task<bool> UpdateRoleAsync(int id, RoleRequestDTO role);
        Task<bool> DeleteRoleAsync(int id);
    }
}
