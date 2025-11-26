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
        public List<Category> GetAllCategories()
        {
            return _categoryRepoitory.GetAllCategories();
        }

    }
}
