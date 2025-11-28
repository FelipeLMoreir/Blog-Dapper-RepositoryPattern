namespace Blog.API.Models.DTOs.Post
{
    public class PostRequestDTO
    {
        public int CategoryId { get; init; } = 0;
        public int AuthorId { get; init; } = 0;
        public string Title { get; init; } = string.Empty;
        public string Summary { get; init; } = string.Empty;
        public string Body { get; init; } = string.Empty;
    }
}
