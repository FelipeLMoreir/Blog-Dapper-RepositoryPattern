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
        public async Task<bool> UpdateCategoryAsync(int id, CategoryRequestDTO category)
        {
            var categoryToUpdate = new Category(
                category.Name,
                category.Name.ToLower().Replace(" ", "-"));

            var rows = await _categoryRepoitory.UpdateCategoryAsync(id, categoryToUpdate);
            return rows > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var rows = await _categoryRepoitory.DeleteCategoryAsync(id);
            return rows > 0;
        }
    }
}
