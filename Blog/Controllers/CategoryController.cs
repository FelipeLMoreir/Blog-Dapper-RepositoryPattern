using Blog.API.Controllers.InterfaceController;
using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Models.DTOs.Category;
using Blog.API.Services;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private CategoryService _categoryService;
        private ILogger<CategoryController> _logger;

        public CategoryController(CategoryService service, ILogger<CategoryController> logger)
        {
            _categoryService = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            _logger.LogInformation("CategoryController HeartBeat checked at {time}", DateTime.UtcNow);
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();

                if (categories is null)
                    return NoContent();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories at {time}", DateTime.UtcNow);

                return Problem(ex.Message);
            }
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                
                if (category is null)
                    return NotFound("Categoria não encontrada!");

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving category with ID {id} at {time}", id, DateTime.UtcNow);
                return Problem(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategory(CategoryRequestDTO category)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(category);

                return Created();
            }
            catch (Exception ex) 
            { 
                _logger.LogError(ex, "An error occurred while creating a category at {time}", DateTime.UtcNow);

                return Problem(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateCategory(int id, CategoryRequestDTO category)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(id, category);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a category at {time}", DateTime.UtcNow);
                return Problem(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a category at {time}", DateTime.UtcNow);
                return Problem(ex.Message);
            }
        }
    }
}
