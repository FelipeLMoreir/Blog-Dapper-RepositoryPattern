using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepository;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlConnection _connection;
        public RoleRepository(ConnectionDB connectionDB)
        {
            _connection = connectionDB.GetConnection();
        }

        public async Task<List<RoleResponseDTO>> GetAllAsync()
        {
            var sql = "SELECT Name, Slug FROM Role";
            return (await _connection.QueryAsync<RoleResponseDTO>(sql)).ToList();
        }

        public async Task<RoleResponseDTO?> GetByIdAsync(int id)
        {
            var sql = "SELECT Name, Slug FROM Role WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<RoleResponseDTO>(sql, new { Id = id });
        }

        public async Task CreateAsync(Role role)
        {
            var sql = "INSERT INTO Role (Name, Slug) VALUES (@Name, @Slug)";
            await _connection.ExecuteAsync(sql, new { role.Name, role.Slug });
        }

        public async Task<int> UpdateAsync(int id, Role role)
        {
            var sql = @"UPDATE Role 
                        SET Name = @Name, Slug = @Slug 
                        WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id, role.Name, role.Slug });
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Role WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
