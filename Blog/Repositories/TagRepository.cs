using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Tag;
using Blog.API.Repositories.InterfaceRepository;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly SqlConnection _connection;
        public TagRepository(ConnectionDB connectionDB)
        {
            _connection = connectionDB.GetConnection();
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            var sql = "SELECT Name, Slug FROM Tag";
            return (await _connection.QueryAsync<TagResponseDTO>(sql)).ToList();
        }

        public async Task CreateAsync(Tag tag)
        {
            var sql = "INSERT INTO Tag (Name, Slug) VALUES (@Name, @Slug)";
            await _connection.ExecuteAsync(sql, new { tag.Name, tag.Slug });
        }

        public async Task<int> UpdateAsync(int id, Tag tag)
        {
            var sql = @"UPDATE Tag 
                        SET Name = @Name, Slug = @Slug 
                        WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id, tag.Name, tag.Slug });
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Tag WHERE Id = @Id";
            return await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
