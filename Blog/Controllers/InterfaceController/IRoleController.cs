using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface IRoleController
    {
        Task<ActionResult<List<RoleResponseDTO>>> GetAll();
        Task<ActionResult<RoleResponseDTO>> GetById(int id);
        Task<ActionResult> Create(RoleRequestDTO dto);
        Task<ActionResult> Update(int id, RoleRequestDTO dto);
        Task<ActionResult> Delete(int id);
    }
}
