using Azure.Core.Pipeline;
using Blog.API.Models;
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
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepoitory.GetAllCategoriesAsync();
        }

    }
}
