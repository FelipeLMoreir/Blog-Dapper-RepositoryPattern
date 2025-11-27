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
        private UserRepository _userRepository;

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
            var slug = userDto.Name
                .ToLower()
                .Trim()
                .Replace(" ", "-");

            var passwordHash = HashPassword(userDto.PasswordPlain);

            var user = new User(
                userDto.Name,
                userDto.Email,
                passwordHash,
                userDto.Bio,
                userDto.Image,
                slug
            );

            await _userRepository.CreateUserAsync(user);
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
