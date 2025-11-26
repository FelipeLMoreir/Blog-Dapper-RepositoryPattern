using Blog.API.Data;
using Blog.API.Models;
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

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            var sql = "SELECT * FROM Category";
            var categories = new List<Category>();

            using (_connection)
            {
                await _connection.OpenAsync();

                var reader = await _connection.ExecuteReaderAsync(sql);

                while (await reader.ReadAsync())
                {
                    var category = new Category(
                        reader["Name"].ToString(),
                        reader["Slug"].ToString()
                    );

                    categories.Add(category);
                }
                return categories;
            }
        }
    }
}
