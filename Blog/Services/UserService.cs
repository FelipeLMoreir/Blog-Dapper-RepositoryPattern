using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;
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

        public async Task CreateUserAsync(UserRequestDTO dto)
        {
            var slug = dto.Name
                .ToLower()
                .Trim()
                .Replace(" ", "-");

            var passwordHash = HashPassword(dto.PasswordPlain);

            var user = new User(
                dto.Name,
                dto.Email,
                passwordHash,
                dto.Bio,
                dto.Image,
                slug
            );

            await _userRepository.CreateUserAsync(user);
        }

        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToHexString(hash); // exemplo simples
        }
    }
}
