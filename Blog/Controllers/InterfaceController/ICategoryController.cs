using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface ICategoryController
    {
        ActionResult HeartBeat();
        Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategories();
        Task<ActionResult> CreateCategory(CategoryRequestDTO category);
        Task<ActionResult> UpdateCategory(int id, CategoryRequestDTO category);
        Task<ActionResult> DeleteCategory(int id);
    }
}