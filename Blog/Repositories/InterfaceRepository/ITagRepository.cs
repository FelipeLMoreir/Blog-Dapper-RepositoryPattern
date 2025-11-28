using Blog.API.Models;
using Blog.API.Models.DTOs.Tag;

namespace Blog.API.Repositories.InterfaceRepository
{
    public interface ITagRepository
    {
        Task<List<TagResponseDTO>> GetAllTagsAsync();
        Task CreateAsync(Tag tag);
        Task<int> UpdateAsync(int id, Tag tag);
        Task<int> DeleteAsync(int id);
    }
}
