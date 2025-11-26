using Blog.API.Data;
using Blog.API.Models;
using Blog.API.Services;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;

        public CategoryController(CategoryService service)
        {
            _categoryService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            await _categoryService.CreateCategoryAsync(category);
                
            return Created();
        }
    }
}
