namespace Blog.API.Models.InterfaceModel
{
    public interface IPost
    {
        int Id { get; }
        int CategoryId { get; }
        int AuthorId { get; }
        string Title { get; }
        string Summary { get; }
        string Body { get; }
        string Slug { get; }
        DateTime CreateDate { get; }
        DateTime LastUpdateDate { get; }
    }
}
