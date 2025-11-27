using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface IRoleRepository
    {
        Task<List<RoleResponseDTO>> GetAllAsync();
        Task<RoleResponseDTO?> GetByIdAsync(int id);
        Task CreateAsync(Role role);
        Task<int> UpdateAsync(int id, Role role);
        Task<int> DeleteAsync(int id);
    }
}
