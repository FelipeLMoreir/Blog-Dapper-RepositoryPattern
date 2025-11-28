namespace Blog.API.Models.DTOs.Post
{
    public class PostResponseDTO
    {
        public int Id { get; init; } = 0;
        public string Title { get; init; } = string.Empty;
        public string Summary { get; init; } = string.Empty;
        public string Body { get; init; } = string.Empty;
        public string Slug { get; init; } = string.Empty;
        public DateTime CreateDate { get; init; } = DateTime.Now;
        public DateTime LastUpdateDate { get; init; } = DateTime.Now;
        public int CategoryId { get; init; } = 0;
        public int AuthorId { get; init; } = 0;
    }
}
