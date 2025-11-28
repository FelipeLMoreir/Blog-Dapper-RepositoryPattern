using Blog.API.Models;
using Blog.API.Models.DTOs.Category;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(Category category);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task UpdateCategoryAsync(int id, Category category);
    }
}
