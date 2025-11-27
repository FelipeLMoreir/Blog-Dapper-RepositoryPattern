using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepository;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly SqlConnection _connection;

        public UserRoleRepository(ConnectionDB connectionDB)
        {
            _connection = connectionDB.GetConnection();
        }

        public async Task AddUserRoleAsync(UserRole userRole)
        {
            const string sql = @"
                INSERT INTO UserRole (UserId, RoleId)
                VALUES (@UserId, @RoleId);";

            await _connection.ExecuteAsync(sql, new
            {
                userRole.UserId,
                userRole.RoleId
            });
        }

        public async Task RemoveUserRoleAsync(int userId, int roleId)
        {
            const string sql = @"
                DELETE FROM UserRole
                WHERE UserId = @UserId AND RoleId = @RoleId;";

            await _connection.ExecuteAsync(sql, new { UserId = userId, RoleId = roleId });
        }

        public async Task<List<UserRoleResponseDTO>> GetRolesByUserAsync(int userId)
        {
            const string sql = @"
                SELECT ur.UserId,
                       u.Name  AS UserName,
                       ur.RoleId,
                       r.Name  AS RoleName
                FROM [User] u
                JOIN UserRole ur ON u.Id = ur.UserId
                JOIN [Role] r    ON r.Id = ur.RoleId
                WHERE u.Id = @UserId;";

            var result = await _connection.QueryAsync<UserRoleResponseDTO>(sql, new { UserId = userId });
            return result.ToList();
        }

        public async Task<List<UserRoleResponseDTO>> GetUsersByRoleAsync(int roleId)
        {
            const string sql = @"
                SELECT ur.UserId,
                       u.Name  AS UserName,
                       ur.RoleId,
                       r.Name  AS RoleName
                FROM [User] u
                JOIN UserRole ur ON u.Id = ur.UserId
                JOIN [Role] r    ON r.Id = ur.RoleId
                WHERE r.Id = @RoleId;";

            var result = await _connection.QueryAsync<UserRoleResponseDTO>(sql, new { RoleId = roleId });
            return result.ToList();
        }
    }
}
