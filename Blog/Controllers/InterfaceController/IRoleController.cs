using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface IRoleController
    {
        Task<ActionResult<List<RoleResponseDTO>>> GetAllRoles();
        Task<ActionResult> CreateRole(RoleRequestDTO dto);
        Task<ActionResult> UpdateRole(int id, RoleRequestDTO dto);
        Task<ActionResult> DeleteRole(int id);
    }
}
