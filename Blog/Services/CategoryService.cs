using Azure.Core.Pipeline;
using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;

namespace Blog.API.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepoitory;
        public CategoryService(CategoryRepository categoryrepository)
        {
            _categoryRepoitory = categoryrepository;
        }
        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            return await _categoryRepoitory.GetAllCategoriesAsync();
        }
        public async Task CreateCategoryAsync(CategoryRequestDTO category)
        {
            var newCategory = new Category(
                                           category.Name,
                                           category.Name.ToLower().Replace(" ", "-"));

            await _categoryRepoitory.CreateCategoryAsync(newCategory);
        }
    }
}
