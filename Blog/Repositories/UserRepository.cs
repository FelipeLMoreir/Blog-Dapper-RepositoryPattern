using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepository;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        public UserRepository(ConnectionDB connectionDB)
        {
            _connection = connectionDB.GetConnection();
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
    }
}
