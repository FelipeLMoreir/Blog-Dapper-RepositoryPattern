namespace Blog.API.Models.InterfaceModel
{
    public interface ICategory
    {
        int Id { get; }
        string Name { get; }
        string Slug { get; }
    }
}
