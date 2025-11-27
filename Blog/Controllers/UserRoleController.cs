using Blog.API.Controllers.InterfaceController;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase, IUserRoleController
    {
        private readonly UserRoleService _userRoleService;

        public UserRoleController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddUserRole([FromBody] UserRoleRequestDTO dto)
        {
            await _userRoleService.AddUserRoleAsync(dto);
            return Created(string.Empty, null);
        }

        [HttpDelete("Remove")]
        public async Task<ActionResult> RemoveUserRole([FromBody] UserRoleRequestDTO dto)
        {
            await _userRoleService.RemoveUserRoleAsync(dto);
            return NoContent();
        }

        [HttpGet("ByUser/{userId:int}")]
        public async Task<ActionResult<List<UserRoleResponseDTO>>> GetRolesByUser(int userId)
        {
            var result = await _userRoleService.GetRolesByUserAsync(userId);
            return Ok(result);
        }

        [HttpGet("ByRole/{roleId:int}")]
        public async Task<ActionResult<List<UserRoleResponseDTO>>> GetUsersByRole(int roleId)
        {
            var result = await _userRoleService.GetUsersByRoleAsync(roleId);
            return Ok(result);
        }
    }
}
