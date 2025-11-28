using Blog.API.Models;
using Blog.API.Models.DTOs.Role;
using Blog.API.Models.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface IUserController
    {
        Task<ActionResult<List<UserResponseDTO>>> GetAllUsers();
        Task<ActionResult> CreateUser([FromBody] UserRequestDTO dto);
        Task<ActionResult> UpdateUser(int id, [FromBody] UserRequestDTO dto);
        Task<ActionResult> DeleteUser(int id);
        Task<ActionResult<List<UserWithRolesDTO>>> GetAllUsersWithRoles();
        Task<ActionResult<List<RoleWithUsersDTO>>> GetAllRolesWithUsers();

    }
}
