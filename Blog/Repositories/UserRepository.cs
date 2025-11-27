using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepository;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(ConnectionDB connectionDB)
        {
            _connection = connectionDB.GetConnection();
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            var sql = "SELECT Name, Email, Bio, Image, Slug FROM [User]";
            return (await _connection.QueryAsync<UserResponseDTO>(sql)).ToList();
        }

        public async Task CreateUserAsync(User user)
        {
            const string sql = @"
                INSERT INTO [User] (Name, Email, PasswordHash, Bio, Image, Slug)
                VALUES (@Name, @Email, @PasswordHash, @Bio, @Image, @Slug);";

            await _connection.ExecuteAsync(sql, new
            {
                user.Name,
                user.Email,
                user.PasswordHash,
                user.Bio,
                user.Image,
                user.Slug
            });
        }

        public async Task<int> UpdateUserAsync(int id, User user)
        {
            const string sql = @"
                UPDATE [User]
                SET Name = @Name,
                    Email = @Email,
                    PasswordHash = @PasswordHash,
                    Bio = @Bio,
                    Image = @Image,
                    Slug = @Slug
                WHERE Id = @Id;";

            return await _connection.ExecuteAsync(sql, new { Id = id,
                user.Name,
                user.Email,
                user.PasswordHash,
                user.Bio,
                user.Image,
                user.Slug
            });

        }

        public async Task<int> DeleteUserAsync(int id)
        {
            const string sql = "DELETE FROM [User] WHERE Id = @Id;";

            return await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
