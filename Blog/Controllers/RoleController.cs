using Blog.API.Controllers.InterfaceController;
using Blog.API.Models.DTOs;
using Blog.API.Services;
using Blog.API.Services.InterfaceService;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase, IRoleController
    {
        private RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleResponseDTO>>> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpPost("CreateTag")]
        public async Task<ActionResult> CreateRole(RoleRequestDTO dto)
        {
            await _roleService.CreateRoleAsync(dto);
            return Created(string.Empty, null);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateRole(int id, RoleRequestDTO dto)
        {
            var updated = await _roleService.UpdateRoleAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var deleted = await _roleService.DeleteRoleAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
