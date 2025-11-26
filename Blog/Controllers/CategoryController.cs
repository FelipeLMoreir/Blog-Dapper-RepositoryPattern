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
        public ActionResult<List<Category>> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpPost("Create")]
        public ActionResult CreateCategory(Category category)
        {
            var sql = "INSERT INTO Category (Name, Slug) VALUES (@Name, @Slug)";
            using (_connection)
            {
                _connection.Open();
                _connection.Execute(sql, new { category.Name, category.Slug });
            }
            return Ok();
        }
    }
}
