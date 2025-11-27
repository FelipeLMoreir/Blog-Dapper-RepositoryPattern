using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface IUserService
    {
        Task CreateUserAsync(UserRequestDTO dto);
    }
}
