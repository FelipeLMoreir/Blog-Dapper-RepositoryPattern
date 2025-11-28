using Blog.API.Models.InterfaceModel;

namespace Blog.API.Models
{
    public class Post : IPost
    {
        public int Id { get; private set; }
        public int CategoryId { get; private set; }
        public int AuthorId { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Body { get; private set; }
        public string Slug { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public List<Tag> Tags { get; private set; } = [];

        public Post(int categoryId, int authorId, string title, string summary, string body, string slug)
        {
            CategoryId = categoryId;
            AuthorId = authorId;
            Title = title;
            Summary = summary;
            Body = body;
            Slug = slug;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
        }

        public Post(int id, int categoryId, int authorId, string title, string summary, 
            string body, string slug, DateTime createDate, DateTime lastUpdateDate)
        {
            Id = id;
            CategoryId = categoryId;
            AuthorId = authorId;
            Title = title;
            Summary = summary;
            Body = body;
            Slug = slug;
            CreateDate = createDate;
            LastUpdateDate = lastUpdateDate;
        }
    }
}
