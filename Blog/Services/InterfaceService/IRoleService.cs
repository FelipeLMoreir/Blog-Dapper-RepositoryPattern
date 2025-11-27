using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface IRoleService
    {
        Task<List<RoleResponseDTO>> GetAllAsync();
        Task<RoleResponseDTO?> GetByIdAsync(int id);
        Task CreateAsync(RoleRequestDTO role);
        Task<bool> UpdateAsync(int id, RoleRequestDTO role);
        Task<bool> DeleteAsync(int id);
    }
}
