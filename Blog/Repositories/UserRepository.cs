using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.User;
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
            var sql = @"
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
            var sql = @"
                UPDATE [User]
                SET Name = @Name,
                    Email = @Email,
                    PasswordHash = @PasswordHash,
                    Bio = @Bio,
                    Image = @Image,
                    Slug = @Slug
                WHERE Id = @Id;";

            return await _connection.ExecuteAsync(sql, new
            {
                Id = id,
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
            var sql = "DELETE FROM [User] WHERE Id = @Id;";

            return await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<List<User>> GetAllUsersWithRolesAsync()
        {
            var sql = @"SELECT 
                        u.Id, u.Name, u.Email, u.PasswordHash, u.Bio, u.Image, u.Slug,
                        r.Id, r.Name, r.Slug
                        FROM [User] u
                        JOIN UserRole ur ON u.Id = ur.UserId
                        JOIN Role r ON ur.RoleId = r.Id;";

            var userDictionary = new Dictionary<int, User>();

            var result = await _connection.QueryAsync<User, Role, User>(
                sql,
                (user, role) =>
                {
                    if (!userDictionary.TryGetValue(user.Id, out var userEntry))
                    {
                        userEntry = user;
                        userDictionary.Add(userEntry.Id, userEntry);
                    }

                    if (role != null)
                        userEntry.addRoles(role); 

                    return userEntry;
                },
                splitOn: "RoleId"
            );

            return userDictionary.Values.ToList();
        }


    }
}
