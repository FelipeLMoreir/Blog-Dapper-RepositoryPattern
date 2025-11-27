using Blog.API.Models;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
    }
}
