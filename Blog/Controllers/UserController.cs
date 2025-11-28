using Blog.API.Controllers.InterfaceController;
using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Models.DTOs.User;
using Blog.API.Services;
using Blog.API.Services.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private UserService _userService;

        public UserController(UserService userService)
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

        [HttpGet("WithRoles")]
        public async Task<ActionResult<List<UserWithRolesDTO>>> GetAllUsersWithRoles()
        {
            var users = await _userService.GetAllUsersWithRolesAsync();
            return Ok(users);
        }

        [HttpGet("WithUsers")]
        public async Task<ActionResult<List<RoleWithUsersDTO>>> GetAllRolesWithUsers()
        {
            var roles = await _userService.GetAllRolesWithUsersAsync();
            return Ok(roles);
        }

    }
}
