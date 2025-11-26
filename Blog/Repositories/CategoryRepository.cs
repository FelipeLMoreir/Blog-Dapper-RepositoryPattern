using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class CategoryRepository
    {
        private readonly SqlConnection _connection;
        public CategoryRepository(ConnectionDB connectionDB)
        {
            _connection = connectionDB.GetConnection();
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            var sql = "SELECT Name, Slug FROM Category";
            //var categories = new List<Category>();

            //using (_connection)
            //{
            //await _connection.OpenAsync();

            //Usando Dapper
            //var categories = (await _connection.QueryAsync<Category>(sql)).ToList();

            //Usando ADO.Net
            //var reader = await _connection.ExecuteReaderAsync(sql);

            //while (await reader.ReadAsync())
            //{
            //    var category = new Category(
            //        reader["Name"].ToString(),
            //        reader["Slug"].ToString()
            //    );

            //    categories.Add(category);
            //}
            return (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();
            //}
        }

        public async Task CreateCategoryAsync(Category category)
        {
            var sql = "INSERT INTO Category (Name, Slug) VALUES (@Name, @Slug)";
            //using (_connection)
            //{
            //await _connection.OpenAsync();
            await _connection.ExecuteAsync(sql, new { category.Name, category.Slug });
            //}
        }
    }
}
