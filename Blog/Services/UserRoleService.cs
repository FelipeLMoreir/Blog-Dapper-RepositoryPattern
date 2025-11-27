using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepository;
using Blog.API.Services.InterfaceService;

namespace Blog.API.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task AddUserRoleAsync(UserRoleRequestDTO dto)
        {
            var userRole = new UserRole(dto.UserId, dto.RoleId);
            await _userRoleRepository.AddUserRoleAsync(userRole);
        }

        public async Task RemoveUserRoleAsync(UserRoleRequestDTO dto)
        {
            await _userRoleRepository.RemoveUserRoleAsync(dto.UserId, dto.RoleId);
        }

        public Task<List<UserRoleResponseDTO>> GetRolesByUserAsync(int userId)
            => _userRoleRepository.GetRolesByUserAsync(userId);

        public Task<List<UserRoleResponseDTO>> GetUsersByRoleAsync(int roleId)
            => _userRoleRepository.GetUsersByRoleAsync(roleId);
    }
}
