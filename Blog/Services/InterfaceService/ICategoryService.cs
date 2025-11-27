using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CategoryRequestDTO category);
        Task UpdateCategoryAsync(int id, CategoryRequestDTO category);
        Task<Category?> GetCategoryByIdAsync(int id);
    }
}
