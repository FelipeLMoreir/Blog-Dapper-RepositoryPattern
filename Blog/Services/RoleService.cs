using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepository;
using Blog.API.Services.InterfaceService;

namespace Blog.API.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<List<RoleResponseDTO>> GetAllAsync()
            => _roleRepository.GetAllAsync();

        public Task<RoleResponseDTO?> GetByIdAsync(int id)
            => _roleRepository.GetByIdAsync(id);

        public async Task CreateAsync(RoleRequestDTO dto)
        {
            var role = new Role(
                dto.Name,
                dto.Name.ToLower().Replace(" ", "-"));
            await _roleRepository.CreateAsync(role);
        }

        public async Task<bool> UpdateAsync(int id, RoleRequestDTO dto)
        {
            var role = new Role(
                dto.Name,
                dto.Name.ToLower().Replace(" ", "-"));
            var rows = await _roleRepository.UpdateAsync(id, role);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var rows = await _roleRepository.DeleteAsync(id);
            return rows > 0;
        }
    }
}
