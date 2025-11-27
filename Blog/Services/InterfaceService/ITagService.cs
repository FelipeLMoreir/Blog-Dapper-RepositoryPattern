using Blog.API.Models.DTOs;

namespace Blog.API.Services.InterfaceService
{
    public interface ITagService
    {
        Task<List<TagResponseDTO>> GetAllTagsAsync();
        Task CreateTagAsync(TagRequestDTO tag);
        Task<bool> UpdateTagAsync(int id, TagRequestDTO tag);
        Task<bool> DeleteTagAsync(int id);
    }
}
