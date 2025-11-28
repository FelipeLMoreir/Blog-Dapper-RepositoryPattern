using Blog.API.Controllers.InterfaceController;
using Blog.API.Models.DTOs.Post;
using Blog.API.Services.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase, IPostController
    {
        private PostService _postService;
        private ILogger<PostController> _logger;

        public PostController(PostService service, ILogger<PostController> logger)
        {
            _postService = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            _logger.LogInformation("PostController HeartBeat checked at {time}", DateTime.UtcNow);
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PostResponseDTO>>> GetAllPostsAsync()
        {
            try
            {
                var posts = await _postService.GetAllPostsAsync();

                if (posts is null)
                    return NoContent();

                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving posts at {time}", DateTime.UtcNow);
                return Problem(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreatePost(PostRequestDTO post)
        {
            try
            {
                await _postService.CreatePostAsync(post);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a post at {time}", DateTime.UtcNow);
                return Problem(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdatePost(int id, PostRequestDTO post)
        {
            try
            {
                await _postService.UpdatePostAsync(id, post);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a post at {time}", DateTime.UtcNow);
                return Problem(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                await _postService.DeletePostAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a post at {time}", DateTime.UtcNow);
                return Problem(ex.Message);
            }
        }
    }
}
