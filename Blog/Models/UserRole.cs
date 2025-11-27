namespace Blog.API.Models
{
    public class UserRole
    {
        public int UserId { get; private set; }
        public int RoleId { get; private set; }

        public User User { get; private set; }
        public Role Role { get; private set; }

        public UserRole(int userId, int roleId)
        {
            this.UserId = userId;
            this.RoleId = roleId;
        }

        public void SetUser(User user)
        {
            this.User = user;
        }
        public void SetRole(Role role)
        {
            this.Role = role;
        }

    }
}
