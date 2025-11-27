using Blog.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface IUserController
    {
        [HttpPost("Create")]
        Task<ActionResult> CreateUser([FromBody] UserRequestDTO dto);

    }
}
