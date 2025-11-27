using Blog.API.Models;
using Blog.API.Models.DTOs;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponseDTO>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(Category category);
        Task<int> UpdateCategoryAsync(int id, Category category);
        Task<int> DeleteCategoryAsync(int id);
    }
}
