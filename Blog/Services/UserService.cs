using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Models.DTOs.User;
using Blog.API.Repositories;
using Blog.API.Repositories.InterfaceRepository;
using Blog.API.Services.InterfaceService;
using System.Security.Cryptography;
using System.Text;

namespace Blog.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task CreateUserAsync(UserRequestDTO userDto)
        {
            var user = BuildUserFromDto(userDto);
            await _userRepository.CreateUserAsync(user);
        }

        public async Task<bool> UpdateUserAsync(int id, UserRequestDTO userDto)
        {
            var user = BuildUserFromDto(userDto);
            var rows = await _userRepository.UpdateUserAsync(id, user);
            return rows > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var rows = await _userRepository.DeleteUserAsync(id);
            return rows > 0;
        }

        private static User BuildUserFromDto(UserRequestDTO dto)
        {
            var slug = dto.Name
                .ToLower()
                .Trim()
                .Replace(" ", "-");

            var passwordHash = HashPassword(dto.PasswordPlain);

            return new User(
                dto.Name,
                dto.Email,
                passwordHash,
                dto.Bio,
                dto.Image,
                slug
            );
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        public async Task<List<UserWithRolesDTO>> GetAllUsersWithRolesAsync()
        {
            var users = await _userRepository.GetAllUsersRoles();

            return users.Select(u => new UserWithRolesDTO
            {
                Name = u.Name,
                Email = u.Email,
                Bio = u.Bio,
                Image = u.Image,
                Slug = u.Slug,
                Roles = u.Roles.Select(r => new RoleWithUsersDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Slug = r.Slug,
                    Users = r.Users.Select(u => new UserWithRolesDTO
                    {
                        Name = u.Name,
                        Email = u.Email,
                        Bio = u.Bio,
                        Image = u.Image,
                        Slug = u.Slug
                    }).ToList()
                }).ToList()
            }).ToList();
        }
        public async Task<List<RoleWithUsersDTO>> GetAllRolesWithUsersAsync()
        {
            var roles = await _userRepository.GetAllRolesUsers(); 

            return roles.Select(r => new RoleWithUsersDTO
            {
                Id = r.Id,
                Name = r.Name,
                Slug = r.Slug,
                Users = r.Users?.Select(u => new UserWithRolesDTO
                {
                    Id = u.Id,
                    Name = u.Name
                }).ToList() ?? new List<UserWithRolesDTO>()
            }).ToList();
        }

    }
}
