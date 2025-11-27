namespace Blog.API.Models.InterfaceModel
{
    public interface IRole
    {
        int Id { get; }
        string Name { get; }
        string Slug { get; }
    }
}
