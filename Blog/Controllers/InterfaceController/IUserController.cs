using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface IUserController
    {
        Task<ActionResult<List<UserResponseDTO>>> GetAllUsers();
        Task<ActionResult> CreateUser([FromBody] UserRequestDTO dto);

    }
}
