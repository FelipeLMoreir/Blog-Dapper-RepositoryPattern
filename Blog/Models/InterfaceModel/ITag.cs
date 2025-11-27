namespace Blog.API.Models.InterfaceModel
{
    public interface ITag
    {
        int Id { get; }
        string Name { get; }
        string Slug { get; }
    }
}
