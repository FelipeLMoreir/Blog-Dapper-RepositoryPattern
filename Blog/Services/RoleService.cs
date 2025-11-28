using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Repositories;
using Blog.API.Repositories.InterfaceRepository;
using Blog.API.Services.InterfaceService;

namespace Blog.API.Services
{
    public class RoleService : IRoleService
    {
        private RoleRepository _roleRepository;
        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task CreateRoleAsync(RoleRequestDTO role)
        {
            var newRole = new Role(
                role.Name,
                role.Name.ToLower().Replace(" ", "-"));
            await _roleRepository.CreateRoleAsync(newRole);
        }

        public async Task<bool> UpdateRoleAsync(int id, RoleRequestDTO role)
        {
            var roleToUpdate = new Role(
                role.Name,
                role.Name.ToLower().Replace(" ", "-"));

            var rows = await _roleRepository.UpdateRoleAsync(id, roleToUpdate);
            return rows > 0;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var rows = await _roleRepository.DeleteRoleAsync(id);
            return rows > 0;
        }
    }
}
