using Blog.API.Models;
using Blog.API.Models.DTOs.Post;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface IPostRepository
    {
        Task<List<PostResponseDTO>> GetAllPostsAsync();
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(int id, Post post);
        Task DeletePostAsync(int id);
    }
}
