using Azure.Core.Pipeline;
using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Repositories;
using Blog.API.Services.InterfaceService;

namespace Blog.API.Services
{
    public class CategoryService : ICategoryService

    {
        private CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryrepository)
        {
            _categoryRepository = categoryrepository;
        }

        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            try
            {
                return await _categoryRepository.GetAllCategoriesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task CreateCategoryAsync(CategoryRequestDTO category)
        {
            try
            {
                var newCategory = new Category(category.Name,
                                                category.Name.ToLower().Replace(" ", "-")
                                                );

                await _categoryRepository.CreateCategoryAsync(newCategory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task UpdateCategoryAsync(int id, CategoryRequestDTO categoryUpdated)
        {
            try
            {
                var category = new Category(categoryUpdated.Name,
                                            categoryUpdated.Name.ToLower().Replace(" ", "-")
                                            );

                await _categoryRepository.UpdateCategoryAsync(id, category);
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
                return await _categoryRepository.GetCategoryByIdAsync(id) ?? null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
