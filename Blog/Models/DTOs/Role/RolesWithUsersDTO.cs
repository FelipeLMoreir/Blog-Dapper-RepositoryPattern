using Blog.API.Models.DTOs.User;

namespace Blog.API.Models.DTOs.Role
{
    public class RoleWithUsersDTO
    {
        public int Id { get; init; } = 0;
        public string Name { get; init; } = string.Empty;
        public string Slug { get; init; } = string.Empty;
        public List<UserWithRolesDTO> Users { get; init; } = new();
    }
}
