using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CategoryRequestDTO category);
        Task<bool> UpdateCategoryAsync(int id, CategoryRequestDTO category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
