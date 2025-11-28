using Blog.API.Models;
using Blog.API.Models.DTOs.Post;

namespace Blog.API.Services.InterfaceService
{
    public interface IPostService
    {
        Task<List<PostResponseDTO>> GetAllPostsAsync();
        Task CreatePostAsync(PostRequestDTO post);
        Task UpdatePostAsync(int id, PostRequestDTO post);
        Task DeletePostAsync(int id);
        Task<List<Post>> GetAllPostsTags();
        Task<List<Tag>> GetAllTagsPosts();

    }
}
