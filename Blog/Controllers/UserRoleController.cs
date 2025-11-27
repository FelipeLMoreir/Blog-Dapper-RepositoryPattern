using Blog.API.Controllers.InterfaceController;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase, IUserRoleController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
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
