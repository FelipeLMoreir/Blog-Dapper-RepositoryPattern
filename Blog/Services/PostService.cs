using Blog.API.Models;
using Blog.API.Models.DTOs.Post;
using Blog.API.Repositories;
using Blog.API.Services.InterfaceService;
using System.Text.RegularExpressions;

namespace Blog.API.Services
{
    public class PostService : IPostService
    {
        private PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<PostResponseDTO>> GetAllPostsAsync()
        {
            try
            {
                return await _postRepository.GetAllPostsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task CreatePostAsync(PostRequestDTO post)
        {
            try
            {
                var slug = GenerateSlug(post.Title);
                var newPost = new Post(
                    post.CategoryId,
                    post.AuthorId,
                    post.Title,
                    post.Summary,
                    post.Body,
                    slug
                );

                await _postRepository.CreatePostAsync(newPost);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task UpdatePostAsync(int id, PostRequestDTO postUpdated)
        {
            try
            {
                var slug = GenerateSlug(postUpdated.Title);
                var post = new Post(
                    postUpdated.CategoryId,
                    postUpdated.AuthorId,
                    postUpdated.Title,
                    postUpdated.Summary,
                    postUpdated.Body,
                    slug
                );

                await _postRepository.UpdatePostAsync(id, post);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public async Task DeletePostAsync(int id)
        {
            try
            {
                await _postRepository.DeletePostAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        private string GenerateSlug(string title)
        {
            string str = title.ToLower().Trim();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = Regex.Replace(str, @"\s+", "-").Trim('-');
            return str;
        }
        public async Task<List<Post>> GetAllPostsTags()
            => await _postRepository.GetAllPostsTags();

        public async Task<List<Tag>> GetAllTagsPosts()
            => await _postRepository.GetAllTagsPosts();

    }
}
