using Blog.API.Controllers.InterfaceController;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser([FromBody] UserRequestDTO dto)
        {
            await _userService.CreateUserAsync(dto);
            return Created(string.Empty, null);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserRequestDTO dto)
        {
            var updated = await _userService.UpdateUserAsync(id, dto);
            if (!updated)
                return NotFound($"User with Id {id} not found.");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted)
                return NotFound($"User with Id {id} not found.");

            return NoContent();
        }
    }
}
