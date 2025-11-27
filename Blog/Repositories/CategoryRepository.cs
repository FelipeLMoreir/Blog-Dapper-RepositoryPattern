using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories.InterfaceRepository;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlConnection _connection;

        private ILogger<CategoryRepository> _logger;

        public CategoryRepository(ConnectionDB connection, ILogger<CategoryRepository> logger)
        {
            _connection = connection.GetConnection();
            _logger = logger;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            try
            {
                var sql = "SELECT Name, Slug FROM Category";

                return (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
            //var sql = "SELECT Name, Slug FROM Category";
            ////var categories = new List<Category>();

            ////using (_connection)
            ////{
            ////await _connection.OpenAsync();

            ////Usando Dapper
            ////var categories = (await _connection.QueryAsync<Category>(sql)).ToList();

            ////Usando ADO.Net
            ////var reader = await _connection.ExecuteReaderAsync(sql);

            ////while (await reader.ReadAsync())
            ////{
            ////    var category = new Category(
            ////        reader["Name"].ToString(),
            ////        reader["Slug"].ToString()
            ////    );

            ////    categories.Add(category);
            ////}
            //return (await _connection.QueryAsync<CategoryResponseDTO>(sql)).ToList();
            ////}
        }

        public async Task CreateCategoryAsync(Category category)
        {
            try
            {
                var sql = "INSERT INTO Category (Name, Slug) VALUES (@Name, @Slug)";

                await _connection.ExecuteAsync(sql, new { category.Name, category.Slug });
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            try
            {
                var sql = "SELECT Id, Name, Slug FROM Category WHERE Id = @Id";

                return await _connection.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task UpdateCategoryAsync(int id, Category category)
        {
            try
            {
                var sql = "UPDATE Category SET Name = @Name, Slug = @Slug WHERE Id = @Id";

                await _connection.ExecuteAsync(sql, new { category.Name, category.Slug, Id = id });
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }
    }
}
