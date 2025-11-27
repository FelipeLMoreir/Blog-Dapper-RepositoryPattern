using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface IUserRoleController
    {
        Task<ActionResult> AddUserRole([FromBody] UserRoleRequestDTO dto);
        Task<ActionResult> RemoveUserRole([FromBody] UserRoleRequestDTO dto);
        Task<ActionResult<List<UserRoleResponseDTO>>> GetRolesByUser(int userId);
        Task<ActionResult<List<UserRoleResponseDTO>>> GetUsersByRole(int roleId);
    }
}
