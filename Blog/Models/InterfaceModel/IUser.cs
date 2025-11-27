namespace Blog.API.Models.InterfaceModel
{
    public interface IUser
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
        string PasswordHash { get; }
        string Bio { get; }
        string Image { get; }
        string Slug { get; }
    }
}
