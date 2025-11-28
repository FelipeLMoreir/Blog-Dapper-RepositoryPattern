using Blog.API.Models.DTOs.Role;

namespace Blog.API.Models.DTOs.User
{
    public class UserWithRolesDTO
    {
        public int Id { get; init; } = 0;
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Bio { get; init; } = string.Empty;
        public string Image { get; init; } = string.Empty;
        public string Slug { get; init; } = string.Empty;
        public List<RoleWithUsersDTO> Roles { get; init; } = new();
    }

}
