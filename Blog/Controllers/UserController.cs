using Blog.API.Models.DTOs;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser([FromBody] UserRequestDTO dto)
        {
            await _userService.CreateUserAsync(dto);
            return Created(string.Empty, null);
        }
    }
}
