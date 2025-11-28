using Blog.API.Models.DTOs.Post;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers.InterfaceController
{
    public interface IPostController
    {
        ActionResult HeartBeat();
        Task<ActionResult<List<PostResponseDTO>>> GetAllPostsAsync();
        Task<ActionResult> CreatePost(PostRequestDTO post);
        Task<ActionResult> UpdatePost(int id, PostRequestDTO post);
        Task<ActionResult> DeletePost(int id);
    }
}
