using Blog.API.Models;
using Blog.API.Models.DTOs;
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
    }
}
